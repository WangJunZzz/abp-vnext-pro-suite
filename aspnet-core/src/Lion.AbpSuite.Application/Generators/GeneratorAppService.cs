namespace Lion.AbpSuite.Generators;

public class GeneratorAppService : AbpSuiteAppService, IGeneratorAppService
{
    private readonly GeneratorManager _generatorManager;
    private readonly TemplateManager _templateManager;
    private readonly ProjectEntityManager _projectEntityManager;
    private readonly EntityModelManager _entityModelManager;
    private readonly ProjectManager _projectManager;
    private readonly TreeManager _treeManager;

    public GeneratorAppService(GeneratorManager generatorManager, TemplateManager templateManager, ProjectEntityManager projectEntityManager,
        EntityModelManager entityModelManager,
        ProjectManager projectManager, TreeManager treeManager)
    {
        _generatorManager = generatorManager;
        _templateManager = templateManager;
        _projectEntityManager = projectEntityManager;
        _entityModelManager = entityModelManager;
        _projectManager = projectManager;
        _treeManager = treeManager;
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
        var result = await RecursionTemplate(template.TemplateDetails, context);
        return FormatResult(result);
    }

    /// <summary>
    /// 合并重复节点
    /// </summary>
    /// <returns></returns>
    private List<TemplateTreeDto> FormatResult(List<TemplateTreeDto> list)
    {
        var treeNodes = ObjectMapper.Map<List<TemplateTreeDto>, List<TreeNode>>(list);
        var distinctResult = _treeManager.Distinct(treeNodes);
        return ObjectMapper.Map<List<TreeNode>, List<TemplateTreeDto>>(distinctResult);
    }

    /// <summary>
    /// 遍历模板
    /// </summary>
    private async Task<List<TemplateTreeDto>> RecursionTemplate(List<TemplateDetailDto> templateDetails, GeneratorProjectTemplateContext context, Guid? parentId = null)
    {
        var tree = new List<TemplateTreeDto>();
        var templates = templateDetails.Where(e => e.ParentId == parentId);
        foreach (var template in templates)
        {
            if (template.TemplateType == TemplateType.Folder)
            {
                var code = await _generatorManager.GeneratorFolderAsync(template.Name);
                tree.Add(code);
                code.Children.AddRange(await RecursionTemplate(templateDetails, context, template.Id));
            }
            else
            {
                tree.AddRange(await _generatorManager.RenderTemplateAsync(context, template));
            }
        }

        return tree;
    }
}