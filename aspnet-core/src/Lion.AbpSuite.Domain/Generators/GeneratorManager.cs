using Lion.AbpSuite.DataTypes;
using Lion.AbpSuite.EntityModels;
using Lion.AbpSuite.Projects;
using Lion.AbpSuite.Projects.Dto.Generators.Render;
using Scriban;
using Scriban.Runtime;
using GeneratorContext = Lion.AbpSuite.Projects.Dto.Generators.Test.GeneratorContext;
using Template = Scriban.Template;
using TemplateContext = Scriban.TemplateContext;

namespace Lion.AbpSuite.Generators;

public class GeneratorManager : AbpSuiteDomainService
{
    private readonly EntityModelManager _entityModelManager;
    private readonly ProjectManager _projectManager;
    private readonly DataTypeManager _dataTypeManager;
    private readonly EnumTypeManager _enumTypeManager;

    public GeneratorManager(
        EntityModelManager entityModelManager,
        ProjectManager projectManager,
        DataTypeManager dataTypeManager,
        EnumTypeManager enumTypeManager)
    {
        _entityModelManager = entityModelManager;
        _projectManager = projectManager;
        _dataTypeManager = dataTypeManager;
        _enumTypeManager = enumTypeManager;
    }

    public async Task<TemplateTreeDto> GenerateAggregateAsync(TemplateDetailDto template, GeneratorProjectResult project, GeneratorEntityModelResult entityModel)
    {
        var result = await GeneratorCodeAsync(template, project, entityModel);
        return result;
    }
    public async Task<TemplateTreeDto> GenerateEntityAsync(TemplateDetailDto template, GeneratorProjectResult project, GeneratorEntityModelResult entityModel)
    {
        var result = await GeneratorCodeAsync(template, project, entityModel);
        return result;
    }
    
    private async Task<TemplateTreeDto> GeneratorCodeAsync(TemplateDetailDto template, GeneratorProjectResult project, GeneratorEntityModelResult entityModel, GeneratorEnumTypeResult enumType = null)
    {
        var fileName = await RenderFileNameAsync(template.Name, project.CompanyName, project.ProjectName, entityModel.AggregateCode, entityModel.Code, enumType?.Code);
        var generatorContext = new GeneratorContext()
        {
            Project = project,
            EntityModel = entityModel,
            EnumType = enumType
        };
        var result = new TemplateTreeDto()
        {
            Key = GuidGenerator.Create(),
            Name = fileName,
            Title = fileName,
            Description = template.Description,
            Content = await RenderAsync(template.Content, new { context = generatorContext }),
            TemplateType = template.TemplateType,
            Icon = AbpSuiteConsts.AntIconFile,
            IsFolder = false
        };

        return result;
    }

    private async Task<string> RenderFileNameAsync(string name, string companyName, string projectName, string aggregateCode, string entityCode, string enumCode)
    {
        var fileName = await RenderAsync(name, new { companyName, projectName, aggregateCode, entityCode, enumCode });
        fileName = fileName.Replace("txt", "cs");
        return fileName;
    }

    /// <summary>
    /// 生成文件夹
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private async Task<TemplateTreeDto> GeneratorFolderAsync(string name)
    {
        var folderName = name;
        var result = new TemplateTreeDto()
        {
            //Key = detail.Id,
            Key = GuidGenerator.Create(),
            Name = folderName,
            Title = folderName,
            TemplateType = TemplateType.Folder,
            Icon = AbpSuiteConsts.AntIconFolder,
            IsFolder = true,
            Content = string.Empty
        };
        return await Task.FromResult(result);
    }

    /// <summary>
    /// 构建生成代码上下文
    /// </summary>
    /// <param name="projectId">项目Id</param>
    /// <returns>GeneratorResult</returns>
    public async Task<GeneratorCodeDto> BuildGeneratorContextAsync(Guid projectId)
    {
        var result = new GeneratorCodeDto();
        // 获取项目
        var project = await _projectManager.GetAsync(projectId);
        result.Project = ObjectMapper.Map<ProjectDto, ProjectContext>(project);
        // 获取实体枚举
        var enumTypes = await _enumTypeManager.ListByProjectIdAsync(projectId);
        result.EnumTypes = ObjectMapper.Map<List<EnumTypeDto>, List<GeneratorEnumTypeResult>>(enumTypes);
        // 获取项目实体
        result.EntityModels = await BuildEntityModelAsync(projectId);
        return result;
    }

    /// <summary>
    /// 构建实体信息
    /// </summary>
    /// <param name="projectId">项目Id</param>
    /// <returns>GeneratorEntityModelResult</returns>
    private async Task<List<EntityModelContext>> BuildEntityModelAsync(Guid projectId)
    {
        var result = new List<EntityModelContext>();
        // 获取实体模型
        var entities = await _entityModelManager.FindByProjectIdAsync(projectId);
        // 获取实体模型数据类型
        var dataTypes = await _dataTypeManager.ListAsync();
        // 获取项目所有枚举
        var enumTypes = await _enumTypeManager.ListByProjectIdAsync(projectId);

        foreach (var entity in entities)
        {
            // 获取聚合根信息
            var currentAggregate = entities.First(e => e.AggregateId == entity.AggregateId);
            var entityModel = new EntityModelContext()
            {
                Id = entity.Id,
                ParentId = entity.ParentId,
                Code = entity.Code,
                Description = entity.Description,
                RelationalType = entity.RelationalType,
                IsRoot = !entity.ParentId.HasValue,
                AggregateCode = currentAggregate.Code
            };
            foreach (var property in entity.EntityModelProperties)
            {
                var entityModelProperty = new EntityModelPropertyContenxt()
                {
                    Id = property.Id,
                    EntityModelId = property.EntityModelId,
                    Code = property.Code,
                    Description = property.Description,
                    IsRequired = property.IsRequired,
                    MaxLength = property.MaxLength,
                    MinLength = property.MinLength,
                    DecimalPrecision = property.DecimalPrecision,
                    DecimalScale = property.DecimalScale,
                    IsEnum = property.EnumTypeId.HasValue ? true : false,
                    EnumTypeId = property.EnumTypeId,
                    DataTypeId = property.DataTypeId,
                };
                // 枚举
                if (entityModelProperty.IsEnum)
                {
                    var currentEnumType = enumTypes.First(e => e.Id == entityModelProperty.EnumTypeId);
                    entityModelProperty.EnumTypeCode = currentEnumType.Code;
                    entityModelProperty.EnumTypeDescription = currentEnumType.Description;
                }
                else
                {
                    var currentDataType = dataTypes.First(e => e.Id == entityModelProperty.EnumTypeId);
                    entityModelProperty.DataTypeCode = currentDataType.Code;
                    entityModelProperty.DataTypeDescription = currentDataType.Description;
                }

                entityModel.Properties.Add(entityModelProperty);
            }

            result.Add(entityModel);
        }

        return result;
    }

    #region 模板渲染

    public async Task<string> RenderAsync(string templateContent, object model)
    {
        try
        {
            var template = Template.Parse(templateContent);
            var context = new TemplateContext();
            var scriptObject = new ScriptObject();
            scriptObject.Import(model, renamer: member => member.Name);
            context.PushGlobal(scriptObject);
            context.MemberRenamer = member => member.Name;
            var result = await template.RenderAsync(context);
            return result;
        }
        catch (Exception e)
        {
            return $"请检查模板是否正确:{e.Message}";
        }
    }

    #endregion
}