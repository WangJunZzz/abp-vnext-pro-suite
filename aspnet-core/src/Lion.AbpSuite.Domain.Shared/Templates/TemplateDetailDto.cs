namespace Lion.AbpSuite.Templates
{
    /// <summary>
    /// 模板明细 
    /// </summary>
    public class TemplateDetailDto : EntityDtoBase<Guid>
    {
        /// <summary>
        /// 模板id
        /// </summary>
        public Guid TemplateId { get; set; }

        /// <summary>
        ///  模板类型
        /// </summary>
        public TemplateType TemplateType { get; set; }
        
        /// <summary>
        /// 模板策略
        /// </summary>
        public ControlType ControlType { get; set; }

        /// <summary>
        /// 父级id
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 模板内容
        /// </summary>
        public string Content { get; set; }
    }
}