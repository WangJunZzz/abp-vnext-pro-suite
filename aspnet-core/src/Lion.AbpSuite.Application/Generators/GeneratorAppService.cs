namespace Lion.AbpSuite.Generators;

public class GeneratorAppService : AbpSuiteAppService, IGeneratorAppService
{
    private readonly GeneratorManager _generatorManager;
    private readonly TemplateManager _templateManager;
    private readonly ProjectEntityManager _projectEntityManager;
    private readonly EntityModelManager _entityModelManager;
    private readonly ProjectManager _projectManager;

    public GeneratorAppService(GeneratorManager generatorManager, TemplateManager templateManager, ProjectEntityManager projectEntityManager,
        EntityModelManager entityModelManager,
        ProjectManager projectManager)
    {
        _generatorManager = generatorManager;
        _templateManager = templateManager;
        _projectEntityManager = projectEntityManager;
        _entityModelManager = entityModelManager;
        _projectManager = projectManager;
    }

    /// <summary>
    /// 预览代码生成
    /// </summary>
    public async Task<string> PreViewAsync(PreViewInput input)
    {
        var template = await _templateManager.GetAsync(input.TemplateId);
        var detail = template.TemplateDetails.FirstOrDefault(e => e.Id == input.TemplateDetailId);
        if (detail == null) throw new UserFriendlyException(message: "模板不存在");
        var entities = await _projectEntityManager.GetAggregateContextAsync(input.AggregateId);
        var result = await _generatorManager.RenderAsync(detail.Content, new { context = entities });
        return result;
    }

    /// <summary>
    /// 预览代码生成
    /// </summary>
    public async Task<List<TemplateTreeDto>> PreViewCodeAsync(PreViewCodeInput input)
    {
        var template = await _templateManager.GetAsync(input.TemplateId);
        if (template.TemplateDetails.Count == 0)
        {
            throw new UserFriendlyException("模板不存在");
        }

        var context = await _projectEntityManager.GetProjectContextAsync(input.ProjectId);
        return await RecursionTemplate(template.TemplateDetails, context);
    }

    /// <summary>
    /// 遍历模板
    /// </summary>
    private async Task<List<TemplateTreeDto>> RecursionTemplate(List<TemplateDetailDto> template, GeneratorProjectTemplateContext context, Guid? parentId = null)
    {
        var tree = new List<TemplateTreeDto>();
        var list = template.Where(e => e.ParentId == parentId);
        foreach (var detail in list)
        {
            if (detail.TemplateType == TemplateType.Folder)
            {
                var folderName = await _generatorManager.RenderAsync(detail.Name, new { projectName = context.Projects.Name });

                var child = new TemplateTreeDto()
                {
                    //Key = detail.Id,
                    Key = GuidGenerator.Create(),
                    Name = folderName,
                    Title = folderName,
                    Description = detail.Description,
                    Content = detail.Content,
                    TemplateType = detail.TemplateType,
                    Icon = "ant-design:folder-open-outlined"
                };
                tree.Add(child);
                child.Children.AddRange(await RecursionTemplate(template, context, detail.Id));
            }
            else
            {
                tree.AddRange(await RenderAggregateAsync(context, detail));
            }
        }

        return tree;
    }

    /// <summary>
    /// 聚合根模板生成
    /// </summary>
    /// <param name="context">实体上下文信息</param>
    /// <param name="template">模板</param>
    private async Task<List<TemplateTreeDto>> RenderAggregateAsync(GeneratorProjectTemplateContext context, TemplateDetailDto template)
    {
        var result = new List<TemplateTreeDto>();
        var s = new TemplateTreeDto();
        var aggregates = context.EntityModels.Where(e => e.IsRoot);
        foreach (var aggregate in aggregates)
        {
            if (template.ControlType == ControlType.Aggregate)
            {
                var itemContext = new GeneratorTemplateContext()
                {
                    Project = context.Projects,
                    EntityModel = aggregate
                };

                var fileName = await _generatorManager.RenderAsync(template.Name, new { projectName = context.Projects.Name, aggregateCode = itemContext.EntityModel.Code });
                fileName = fileName.Replace("txt", "cs");

                var childContent = new TemplateTreeDto()
                {
                    //Key = template.Id,
                    Key = GuidGenerator.Create(),
                    Name = fileName,
                    Title = fileName,
                    Description = template.Description, Content = await _generatorManager.RenderAsync(template.Content, new { context = itemContext }),
                    TemplateType = template.TemplateType,
                    Icon = "ant-design:file-outlined"
                };
                result.Add(childContent);
                s.Children.Add(childContent);
            }
            else
            {
                result.AddRange(await RenderEntityAsync(context, template, aggregate.EntityModels));
                s.Children.First().Children.AddRange(await RenderEntityAsync(context, template, aggregate.EntityModels));
            }
        }

        return result;
    }

    /// <summary>
    /// 实体模板生成
    /// </summary>
    /// <param name="context">实体上下文信息</param>
    /// <param name="template">模板</param>
    /// <param name="entityModelContexts">当前实体</param>
    private async Task<List<TemplateTreeDto>> RenderEntityAsync(GeneratorProjectTemplateContext context, TemplateDetailDto template,
        List<GeneratorEntityModelContext> entityModelContexts)
    {
        var result = new List<TemplateTreeDto>();
        if (template.ControlType != ControlType.Entity) return result;
        foreach (var entity in entityModelContexts)
        {
            var itemContext = new GeneratorTemplateContext()
            {
                Project = context.Projects,
                EntityModel = entity
            };
            var fileName = await _generatorManager.RenderAsync(template.Name, new { projectName = context.Projects.Name, entityCode = itemContext.EntityModel.Code });
            fileName = fileName.Replace("txt", "cs");
            var childContent = new TemplateTreeDto()
            {
                //Key = template.Id,
                Key = GuidGenerator.Create(),
                Name = fileName,
                Title = fileName,
                Description = template.Description,
                Content = await _generatorManager.RenderAsync(template.Content, new { context = itemContext }),
                TemplateType = template.TemplateType,
                Icon = "ant-design:file-outlined"
            };
            result.Add(childContent);
            result.AddRange(await RenderEntityAsync(context, template, entity.EntityModels));
        }

        return result;
    }


    private string GetFileName(string text)
    {
        if (text.IsNullOrWhiteSpace()) throw new UserFriendlyException("文件名为空");
        var temp = text.Split(".", StringSplitOptions.RemoveEmptyEntries).ToList();
        if (temp == null || temp.Count < 1) throw new UserFriendlyException("文件名格式不正确");

        return temp[temp.Count - 2] + "." + temp.Last();
    }

    private List<string> GetDirectory(string text)
    {
        var result = new List<string>();
        if (text.IsNullOrWhiteSpace()) throw new UserFriendlyException("文件名为空");
        var temp = text.Split(".", StringSplitOptions.RemoveEmptyEntries).ToList();
        if (temp == null || temp.Count < 1) throw new UserFriendlyException("文件名格式不正确");
        for (int i = 0; i < temp.Count - 2; i++)
        {
            result.Add(temp[i]);
        }

        return result;
    }
}