using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Lion.AbpSuite.Templates.Aggregates
{
    /// <summary>
    /// 模板明细 
    /// </summary>
    public class TemplateDetail : AuditedEntity<Guid>
    {
        /// <summary>
        /// 模板id
        /// </summary>
        public Guid TemplateId { get; private set; }

        /// <summary>
        /// 父级id
        /// </summary>
        public Guid? ParentId { get; private set; }

        /// <summary>
        /// 模板名称
        /// </summary>

        public string Name { get; private set; }

        /// <summary>
        /// 模板内容
        /// </summary>
        public string Content { get; private set; }


        private TemplateDetail()
        {
        }

        public TemplateDetail(
            Guid id,
            Guid templateId,
            string name,
            string content,
            Guid? parentId = null
        ) : base(id)
        {
            TemplateId = templateId;
            ParentId = parentId;
            SetName(name);
            SetContent(content);
        }


        private void SetName(string name)
        {
            Guard.NotNullOrWhiteSpace(name, nameof(name), AbpSuiteDomainSharedConsts.MaxLength128);
            Name = name;
        }

        private void SetContent(string cotent)
        {
            Content = cotent;
        }

        public void Update(string name, string content)
        {
            SetName(name);
            SetContent(content);
        }
        
        public void Update()
        {
            
        }
    }
}