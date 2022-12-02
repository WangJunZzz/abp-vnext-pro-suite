namespace Lion.AbpSuite.EnumTypes.Aggregates
{
    /// <summary>
    /// 枚举 
    /// </summary>
    public class EnumType : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; private set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; private set; }


        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 实体模型Id
        /// </summary>
        public Guid EntityModelId { get; private set; }
        
        /// <summary>
        /// 项目Id
        /// </summary>
        public Guid ProjectId { get; private set; }

        public List<EnumTypeProperty> EnumTypeProperties { get; set; }

        private EnumType()
        {
            EnumTypeProperties = new List<EnumTypeProperty>();
        }

        public EnumType(
            Guid id,
            string code,
            string description,
            Guid entityModelId,
            Guid projectId,
            Guid? tenantId
        ) : base(id)
        {
            TenantId = tenantId;
            SetCode(code);
            SetDescription(description);
            SetEntityModelId(entityModelId);
            ProjectId = projectId;
            EnumTypeProperties = new List<EnumTypeProperty>();
        }


        private void SetCode(string code)
        {
            Guard.NotNullOrWhiteSpace(code, nameof(code), AbpSuiteDomainSharedConsts.MaxLength128);
            Code = code;
        }


        private void SetDescription(string description)
        {
            Guard.NotNullOrWhiteSpace(description, nameof(description), AbpSuiteDomainSharedConsts.MaxLength128);
            Description = description;
        }

        private void SetEntityModelId(Guid entityModelId)
        {
            EntityModelId = entityModelId;
        }

        public void Update(string code, string description)
        {
            SetCode(code);
            SetDescription(description);
        }

        public void AddPropery(Guid id, string code, int value, string description)
        {
            if (EnumTypeProperties.Any(e => e.Code == code))
            {
                throw new UserFriendlyException("枚举属性已存在");
            }
            if (EnumTypeProperties.Any(e => e.Value == value))
            {
                throw new UserFriendlyException("枚举值已存在");
            }
            EnumTypeProperties.Add(new EnumTypeProperty(id, Id, code, value, description));
        }

        public void UpdatePropery(Guid id, string code, int value, string description)
        {
            var propertyCode = EnumTypeProperties.FirstOrDefault(e => e.Code == code && e.Id != id);

            if (propertyCode != null)
            {
                throw new UserFriendlyException("枚举属性已存在");
            }

            var propertyValue = EnumTypeProperties.FirstOrDefault(e => e.Value == value && e.Id != id);
            if (propertyValue != null)
            {
                throw new UserFriendlyException("枚举属性值已存在");
            }

            var property = EnumTypeProperties.FirstOrDefault(e => e.Id == id);
            if (property == null)
            {
                throw new UserFriendlyException("枚举属性不存在");
            }

            property.Update(code, value, description);
        }

        public void DeletePropery(Guid id)
        {
            var property = EnumTypeProperties.FirstOrDefault(e => e.Id == id);
            if (property == null)
            {
                throw new UserFriendlyException("枚举属性不存在");
            }

            property.Delete();
        }
    }
}