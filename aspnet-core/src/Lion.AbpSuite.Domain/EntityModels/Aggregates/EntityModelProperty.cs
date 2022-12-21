namespace Lion.AbpSuite.EntityModels.Aggregates
{
    /// <summary>
    /// 实体模型属性 
    /// </summary>
    public class EntityModelProperty : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 必填
        /// </summary>
        public bool IsRequired { get; private set; }

        /// <summary>
        /// 字符串最大长度
        /// </summary>
        public int? MaxLength { get; private set; }

        /// <summary>
        /// 字符串最小长度
        /// </summary>
        public int? MinLength { get; private set; }

        /// <summary>
        /// 当类型为decimal时的小数位数 (18,4) 中的18
        /// </summary>
        public int? DecimalPrecision { get; private set; }

        /// <summary>
        /// 当类型为decimal时的字段长度 (18,4) 中的4
        /// </summary>
        public int? DecimalScale { get; private set; }

        /// <summary>
        /// 枚举类型Id
        /// </summary>
        public Guid? EnumTypeId { get; private set; }

        /// <summary>
        /// 数据类型Id
        /// </summary>
        public Guid? DataTypeId { get; private set; }

        /// <summary>
        /// 实体模型Id
        /// </summary>
        public Guid EntityModelId { get; private set; }


        private EntityModelProperty()
        {
        }

        public EntityModelProperty(
            Guid id,
            string code,
            string description,
            bool isRequired,
            int? maxLength,
            int? minLength,
            int? decimalPrecision,
            int? decimalScale,
            Guid? enumTypeId,
            Guid? dataTypeId,
            Guid entityModelId
        ) : base(id)
        {
            SetCode(code);
            SetDescription(description);
            SetIsRequired(isRequired);
            SetMaxLength(maxLength);
            SetMinLength(minLength);
            SetDecimalPrecision(decimalPrecision);
            SetDecimalScale(decimalScale);
            SetEnumTypeId(enumTypeId);
            SetDataTypeId(dataTypeId);
            SetEntityModelId(entityModelId);
        }

        public void Update(
            string code,
            string description,
            bool isRequired,
            int? maxLength,
            int? minLength,
            int? decimalPrecision,
            int? decimalScale,
            Guid? enumTypeId,
            Guid? dataTypeId
        )
        {
            SetCode(code);
            SetDescription(description);
            SetIsRequired(isRequired);
            SetMaxLength(maxLength);
            SetMinLength(minLength);
            SetDecimalPrecision(decimalPrecision);
            SetDecimalScale(decimalScale);
            SetEnumTypeId(enumTypeId);
            SetDataTypeId(dataTypeId);
        }

        public void Delete()
        {
            IsDeleted = true;
            DeletionTime = DateTime.Now;
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

        private void SetIsRequired(bool isRequired)
        {
            IsRequired = isRequired;
        }

        private void SetMaxLength(int? maxLength)
        {
            if (maxLength.HasValue)
            {
                Guard.GreaterThan(maxLength.Value, nameof(maxLength), 0, true);
            }

            MaxLength = maxLength;
        }

        private void SetMinLength(int? minLength)
        {
            if (minLength.HasValue)
            {
                Guard.GreaterThan(minLength.Value, nameof(minLength), 0, true);
            }

            MinLength = minLength;
        }

        private void SetDecimalPrecision(int? decimalPrecision)
        {
            if (decimalPrecision.HasValue)
            {
                Guard.GreaterThan(decimalPrecision.Value, nameof(decimalPrecision), 0);
            }

            DecimalPrecision = decimalPrecision;
        }

        private void SetDecimalScale(int? decimalScale)
        {
            if (decimalScale.HasValue)
            {
                Guard.GreaterThan(decimalScale.Value, nameof(decimalScale), 0);
            }

            DecimalScale = decimalScale;
        }

        private void SetEnumTypeId(Guid? enumTypeId)
        {
            if (enumTypeId.HasValue)
            {
                EnumTypeId = enumTypeId;
                DataTypeId = null;
            }
        }

        private void SetDataTypeId(Guid? dataTypeId)
        {
            if (dataTypeId.HasValue)
            {
                DataTypeId = dataTypeId;
                EnumTypeId = null;
            }
        }

        private void SetEntityModelId(Guid entityModelId)
        {
            EntityModelId = entityModelId;
        }
    }
}