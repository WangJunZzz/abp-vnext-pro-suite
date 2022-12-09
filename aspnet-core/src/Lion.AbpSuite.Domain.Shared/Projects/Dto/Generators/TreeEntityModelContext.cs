﻿using Lion.AbpSuite.EntityModels;

namespace Lion.AbpSuite.Projects.Dto.Generators;

/// <summary>
/// 树形实体上下文
/// </summary>
public class TreeEntityModelContext
{
    public TreeEntityModelContext()
    {
        Properties = new List<TreeEntityModelPropertyContext>();
        EntityModels = new List<TreeEntityModelContext>();
        EnumTypes = new List<EnumTypeContext>();
    }

    public Guid Id { get; set; }
    
    public Guid? ParentId { get; set; }
    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 首字母小写
    /// </summary>
    public string CodeCamelCase => Code.Camelize();

    /// <summary>
    /// 复数形式
    /// </summary>
    public string CodePluralized => Code.Pluralize();

    /// <summary>
    /// 聚合根编码
    /// </summary>
    public string AggregateCode { get; set; }

    /// <summary>
    /// 首字母小写
    /// </summary>
    public string AggregateCodeCamelCase => AggregateCode.Camelize();

    /// <summary>
    /// 复数形式
    /// </summary>
    public string AggregateCodePluralized => AggregateCode.Pluralize();

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 是否是聚合根
    /// </summary>
    public bool IsRoot { get; set; }

    /// <summary>
    /// 实体关系
    /// </summary>
    public RelationalType? RelationalType { get; set; }


    /// <summary>
    /// 实体模型属性集合
    /// </summary>
    public List<TreeEntityModelPropertyContext> Properties { get; set; }

    /// <summary>
    /// 实体拥有枚举集合
    /// </summary>
    public List<EnumTypeContext> EnumTypes { get; set; }

    public List<TreeEntityModelContext> EntityModels { get; set; }
}