namespace Lion.AbpSuite.Projects.Aggregates
{
    /// <summary>
    /// 项目 
    /// </summary>
    public class Project : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; private set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string Owner { get; private set; }

        /// <summary>
        /// 名称空间
        /// </summary>
        public string NameSpace { get; private set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; private set; }

        public string CompanyName { get; private set; }

        public string ProjectName { get;  private set; }

        private Project()
        {
        }

        public Project(
            Guid id,
            string name,
            string owner,
            string companyName,
            string projectName,
            string remark = null,
            Guid? tenantId = null
        ) : base(id)
        {
            TenantId = tenantId;
            SetName(name);
            SetOwner(owner);
            SetNameSpace(companyName,projectName);
            SetRemark(remark);
        }


        private void SetName(string name)
        {
            Guard.NotNullOrWhiteSpace(name, nameof(name), AbpSuiteDomainSharedConsts.MaxLength128);
            Name = name;
        }

        private void SetOwner(string owner)
        {
            if (owner.IsNullOrWhiteSpace())
            {
                Owner = string.Empty;
                return;
            }

            Owner = owner;
        }


        public void SetNameSpace(string companyName, string projectName)
        {
            Guard.NotNullOrWhiteSpace(companyName, nameof(companyName), AbpSuiteDomainSharedConsts.MaxLength128);
            Guard.NotNullOrWhiteSpace(projectName, nameof(projectName), AbpSuiteDomainSharedConsts.MaxLength128);
            NameSpace = string.Concat(companyName, ".", projectName);
            CompanyName = companyName;
            ProjectName = projectName;
        }


        private void SetRemark(string remark)
        {
            if (remark.IsNullOrWhiteSpace())
            {
                Remark = string.Empty;
                return;
            }

            Remark = remark;
        }

        public void Update(string name, string companyName, string projectName, string owner, string remark)
        {
            SetName(name);
            SetOwner(owner);
            SetNameSpace(companyName, projectName);
            SetRemark(remark);
        }
    }
}