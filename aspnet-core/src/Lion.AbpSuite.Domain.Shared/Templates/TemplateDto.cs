
namespace Lion.AbpSuite.Templates
{
    /// <summary>
    /// 模板 
    /// </summary>
    public  class TemplateDto : AggregateDtoBase<Guid>
    {
        public Guid? TenantId { get;  set; }
        
        
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }


        /// <summary>
        /// 关联属性1:N 模板明细集合
        /// </summary>
        public List<TemplateDetailDto> TemplateDetails { get; set; }

        public TemplateDto()
        {
            TemplateDetails = new List<TemplateDetailDto>();
        }
    }
}