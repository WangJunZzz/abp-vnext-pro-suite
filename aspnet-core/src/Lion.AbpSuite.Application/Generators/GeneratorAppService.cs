namespace Lion.AbpSuite.Generators;

public class GeneratorAppService : AbpSuiteAppService, IGeneratorAppService
{
    private readonly GeneratorManager _generatorManager;
    private readonly TemplateManager _templateManager;
    private readonly ProjectEntityManager _projectEntityManager;
    private readonly TreeManager _treeManager;
    private readonly FileHelper _fileHelper;

    public GeneratorAppService(
        GeneratorManager generatorManager, 
        TemplateManager templateManager,
        ProjectEntityManager projectEntityManager,
        TreeManager treeManager,
        FileHelper fileHelper)
    {
        _generatorManager = generatorManager;
        _templateManager = templateManager;
        _projectEntityManager = projectEntityManager;
        _treeManager = treeManager;
        _fileHelper = fileHelper;
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
    /// 下载源码
    /// </summary>
    public async Task<ActionResult> DownCodeAsync(DownCodeInput input)
    {
        var path = Path.Combine(Environment.CurrentDirectory, "Code", Clock.Now.ToShortDateString());
        var zipPath = Path.Combine(Environment.CurrentDirectory, "Code", "源码.zip");
        try
        {
            _fileHelper.CreateDirectory(path);
            var codes = await PreViewCodeAsync(new PreViewCodeInput()
            {
                ProjectId = input.ProjectId,
                TemplateId = input.TemplateId
            });
            foreach (var code in codes)
            {
                if (code.IsFolder)
                {
                    var directory = Path.Combine(path, code.Name);
                    _fileHelper.CreateDirectory(directory);
                    await RecursionFile(code.Children, directory);
                }
                else
                {
                    await _fileHelper.CreateFileAsync(path, code.Content);
                }
            }

            ZipFile.CreateFromDirectory(path, zipPath);
            var bytes = await File.ReadAllBytesAsync(zipPath);
            return new FileContentResult(bytes, "application/zip")
            {
                FileDownloadName = "源码.zip"
            };
        }
        finally
        {
            _fileHelper.DeleteDirectory(path);
            _fileHelper.DeleteFile(zipPath);
        }
    }

    /// <summary>
    /// 遍历模板
    /// </summary>
    private async Task RecursionFile(List<TemplateTreeDto> codes, string path)
    {
        foreach (var code in codes)
        {
            var currentPath = path;
            if (code.IsFolder)
            {
                currentPath = Path.Combine(currentPath, code.Name);
                _fileHelper.CreateDirectory(currentPath);

                await RecursionFile(code.Children, currentPath);
            }
            else
            {
                var fileName = Path.Combine(path, code.Name);
                await _fileHelper.CreateFileAsync(fileName, code.Content);
            }
        }
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