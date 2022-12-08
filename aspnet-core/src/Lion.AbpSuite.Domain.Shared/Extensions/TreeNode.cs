using Lion.AbpSuite.Templates;

namespace Lion.AbpSuite.Extensions;

public class TreeNode
{
    public Guid Key { get; set; }
    
    /// <summary>
    ///  模板类型
    /// </summary>
    public TemplateType TemplateType { get; set; }
    
    /// <summary>
    /// 图标
    /// </summary>
    public string Icon { get; set; }
    
    /// <summary>
    /// 是否是文件夹
    /// </summary>
    public bool IsFolder { get; set; }
    
    /// <summary>
    /// 模板名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get;  set; }
    
    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// 模板内容
    /// </summary>
    public string Content { get; set; }

    
    /// <summary>
    /// 判断是否有需要合并的
    /// </summary>
    public string FullTitle { get; set; }

    /// <summary>
    /// 父级全标题 用来关联合并后的层级关系
    /// </summary>
    public string ParentFullTitle { get; set; }

    /// <summary>
    /// 节点深度
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// 子节点
    /// </summary>

    public List<TreeNode> Children = new List<TreeNode>();
}