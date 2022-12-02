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

    private async Task<List<TemplateTreeDto>> RecursionTemplate(List<TemplateDetailDto> template, GeneratorProjectTemplateContext context, Guid? parentId = null)
    {
        var tree = new List<TemplateTreeDto>();
        var list = template.Where(e => e.ParentId == parentId);
        foreach (var detail in list)
        {
            if (detail.TemplateType == TemplateType.Folder)
            {
                detail.Name = await _generatorManager.RenderAsync(detail.Name, new { projectName = context.Projects.Name, entityName = context.Projects.Name });

                var child = new TemplateTreeDto()
                {
                    Key = detail.Id,
                    Name = detail.Name,
                    Title = detail.Description,
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
                var aggregates = context.EntityModels.Where(e => e.IsRoot);
                foreach (var aggregate in aggregates)
                {
                    var itemContext = new GeneratorTemplateContext()
                    {
                        Project = context.Projects,
                        EntityModel = aggregate
                    };

                    var childContent = new TemplateTreeDto()
                    {
                        Key = detail.Id,
                        Name = detail.Name,
                        Title = detail.Description,
                        Description = detail.Description,
                        Content = await _generatorManager.RenderAsync(detail.Content, new { context = itemContext }),
                        TemplateType = detail.TemplateType,
                        Icon = "ant-design:file-outlined"
                    };

                    tree.Add(childContent);
                }
            }
        }

        return tree;
    }
}