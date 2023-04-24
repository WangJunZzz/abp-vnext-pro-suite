namespace Lion.AbpSuite.Projects;

public class ProjectEntityManager : AbpSuiteDomainService
{
    private readonly EntityModelManager _entityModelManager;
    private readonly ProjectManager _projectManager;
    private readonly DataTypeManager _dataTypeManager;
    private readonly EnumTypeManager _enumTypeManager;

    public ProjectEntityManager(EntityModelManager entityModelManager, ProjectManager projectManager,
        DataTypeManager dataTypeManager, EnumTypeManager enumTypeManager)
    {
        _entityModelManager = entityModelManager;
        _projectManager = projectManager;
        _dataTypeManager = dataTypeManager;
        _enumTypeManager = enumTypeManager;
    }

    /// <summary>
    /// 获取上下文信息
    /// </summary>
    /// <param name="projectId">项目id</param>
    public async Task<GeneratorProjectTemplateContext> GetProjectContextAsync(Guid projectId)
    {
        var result = new GeneratorProjectTemplateContext();
        var entities = await _entityModelManager.FindByProjectIdAsync(projectId);

        // 获取实体模型数据类型
        var dataTypes = await _dataTypeManager.ListAsync();
        // 获取实体枚举
        var enumTypes = await _enumTypeManager.ListByProjectIdAsync(projectId);
        result.TreeEntityModels = RecursionEntity(entities, null, dataTypes, enumTypes);
        var project = await _projectManager.GetAsync(projectId);
        result.Project = ObjectMapper.Map<ProjectDto, GeneratorProjectContext>(project);
        result.EntityModels = BuildEntityModelContext(entities, dataTypes, enumTypes);
        return result;
    }

    private List<GeneratorEntityModelContext> BuildEntityModelContext(List<EntityModelDto> entities, List<DataTypeDto> dataTypes, List<EnumTypeDto> enumTypes)
    {
        var result = new List<GeneratorEntityModelContext>();
        foreach (var detail in entities)
        {
            // 找到实体聚合根信息
            var aggregate = entities.First(e => e.Id == detail.AggregateId);
            var child = new GeneratorEntityModelContext()
            {
                Id = detail.Id,
                Code = detail.Code,
                Description = detail.Description,
                RelationalType = detail.RelationalType,
                IsRoot = !detail.ParentId.HasValue,
                AggregateCode = aggregate.Code
            };

            foreach (var detailEntityModelProperty in detail.EntityModelProperties)
            {
                #region 属性

                var property = new GeneratorEntityModelPropertyContext()
                {
                    Id = detailEntityModelProperty.Id,
                    Code = detailEntityModelProperty.Code,
                    Description = detailEntityModelProperty.Description,
                    IsRequired = detailEntityModelProperty.IsRequired,
                    MaxLength = detailEntityModelProperty.MaxLength,
                    MinLength = detailEntityModelProperty.MinLength,
                    DecimalPrecision = detailEntityModelProperty.DecimalPrecision,
                    DecimalScale = detailEntityModelProperty.DecimalScale,
                    EnumTypeId = detailEntityModelProperty.EnumTypeId,
                    IsEnum = detailEntityModelProperty.EnumTypeId.HasValue,
                    IsDataType = detailEntityModelProperty.DataTypeId.HasValue,
                    DataTypeId = detailEntityModelProperty.DataTypeId,
                    EntityModelId = detailEntityModelProperty.EntityModelId,
                };
                if (property.IsEnum)
                {
                    var currentEnum = enumTypes.FirstOrDefault(e => property.EnumTypeId != null && e.Id == property.EnumTypeId.Value);

                    if (currentEnum != null)
                    {
                        var enumType = new GeneratorEnumTypeContext()
                        {
                            Id = currentEnum.Id,
                            Code = currentEnum.Code,
                            Description = currentEnum.Description
                        };
                        foreach (var currentEnumEnumTypeProperty in currentEnum.EnumTypeProperties)
                        {
                            enumType.Properties.Add(new GeneratorEnumTypePropertyContext()
                            {
                                Id = currentEnumEnumTypeProperty.Id,
                                Code = currentEnumEnumTypeProperty.Code,
                                Description = currentEnumEnumTypeProperty.Description,
                                Value = currentEnumEnumTypeProperty.Value
                            });
                        }

                        property.EnumType = enumType;
                    }
                }
                else
                {
                    var currentData = dataTypes.FirstOrDefault(e => property.DataTypeId != null && e.Id == property.DataTypeId.Value);
                    if (currentData != null)
                    {
                        property.DataType = new GeneratorDataTypeContext()
                        {
                            Id = currentData.Id,
                            Code = currentData.Code,
                            Description = currentData.Description
                        };
                    }
                }

                var dataType = property.IsEnum ? property.EnumType.Code : property.DataType.Code;
                property.Null = FormatNull(detailEntityModelProperty.IsRequired, dataType);
                child.Properties.Add(property);

                #endregion
            }

            result.Add(child);
        }

        return result;
    }


    private string FormatNull(bool isRequired, string code)
    {
        if (code.ToLower() != "string" && !isRequired)
        {
            return "?";
        }

        return String.Empty;
    }

    private List<GeneratorTreeEntityModelContext> RecursionEntity(List<EntityModelDto> entities, Guid? parentId, List<DataTypeDto> dataTypes, List<EnumTypeDto> enumTypes)
    {
        var tree = new List<GeneratorTreeEntityModelContext>();
        var list = entities.Where(e => e.ParentId == parentId);
        foreach (var detail in list)
        {
            // 找到实体聚合根信息
            var aggregate = entities.First(e => e.Id == detail.AggregateId);
            var child = new GeneratorTreeEntityModelContext()
            {
                Id = detail.Id,
                Code = detail.Code,
                Description = detail.Description,
                RelationalType = detail.RelationalType,
                IsRoot = !detail.ParentId.HasValue,
                AggregateCode = aggregate.Code
            };

            foreach (var detailEntityModelProperty in detail.EntityModelProperties)
            {
                var property = new GeneratorTreeEntityModelPropertyContext()
                {
                    Id = detailEntityModelProperty.Id,
                    Code = detailEntityModelProperty.Code,
                    Description = detailEntityModelProperty.Description,
                    IsRequired = detailEntityModelProperty.IsRequired,
                    MaxLength = detailEntityModelProperty.MaxLength,
                    MinLength = detailEntityModelProperty.MinLength,
                    DecimalPrecision = detailEntityModelProperty.DecimalPrecision,
                    DecimalScale = detailEntityModelProperty.DecimalScale,
                    EnumTypeId = detailEntityModelProperty.EnumTypeId,
                    IsEnum = detailEntityModelProperty.EnumTypeId.HasValue,
                    IsDataType = detailEntityModelProperty.DataTypeId.HasValue,
                    DataTypeId = detailEntityModelProperty.DataTypeId,
                    EntityModelId = detailEntityModelProperty.EntityModelId,
                };
                if (property.IsEnum)
                {
                    var currentEnum = enumTypes.FirstOrDefault(e => property.EnumTypeId != null && e.Id == property.EnumTypeId.Value);

                    if (currentEnum != null)
                    {
                        var enumType = new GeneratorEnumTypeContext()
                        {
                            Id = currentEnum.Id,
                            Code = currentEnum.Code,
                            Description = currentEnum.Description
                        };
                        foreach (var currentEnumEnumTypeProperty in currentEnum.EnumTypeProperties)
                        {
                            enumType.Properties.Add(new GeneratorEnumTypePropertyContext()
                            {
                                Id = currentEnumEnumTypeProperty.Id,
                                Code = currentEnumEnumTypeProperty.Code,
                                Description = currentEnumEnumTypeProperty.Description,
                                Value = currentEnumEnumTypeProperty.Value
                            });
                        }

                        property.EnumType = enumType;
                        child.EnumTypes.Add(enumType);
                    }
                }
                else
                {
                    var currentData = dataTypes.FirstOrDefault(e => property.DataTypeId != null && e.Id == property.DataTypeId.Value);
                    if (currentData != null)
                    {
                        property.DataType = new GeneratorDataTypeContext()
                        {
                            Id = currentData.Id,
                            Code = currentData.Code,
                            Description = currentData.Description
                        };
                    }
                }

                var dataType = property.IsEnum ? property.EnumType.Code : property.DataType.Code;
                property.Null = FormatNull(detailEntityModelProperty.IsRequired, dataType);
                child.Properties.Add(property);
            }

            child.EntityModels.AddRange(RecursionEntity(entities, detail.Id, dataTypes, enumTypes));
            tree.Add(child);
        }

        return tree;
    }
}