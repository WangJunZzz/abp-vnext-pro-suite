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

        private Project()
        {
        }

        public Project(
            Guid id,
            string name,
            string owner,
            string nameSpace,
            string remark = null,
            Guid? tenantId = null
        ) : base(id)
        {
            TenantId = tenantId;
            SetName(name);
            SetOwner(owner);
            SetNameSpace(nameSpace);
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

        private void SetNameSpace(string nameSpace)
        {
            Guard.Length(nameSpace, nameof(nameSpace), AbpSuiteDomainSharedConsts.MaxLength512);
            NameSpace = nameSpace;
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

        public void Update(string name, string nameSpace, string owner, string remark)
        {
            SetName(name);
            SetOwner(owner);
            SetNameSpace(nameSpace);
            SetRemark(remark);
        }
    }
}