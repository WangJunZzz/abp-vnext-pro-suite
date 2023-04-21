namespace Lion.AbpSuite.EntityModels;

public interface IEntityModelAppService : IApplicationService
{
    Task<PagedResultDto<PageEntityModelPropertyOutput>> PagePropertyAsync(PageEntityModelInput input);

    /// <summary>
    /// 创建聚合根
    /// </summary>
    Task CreateAggregateAsync(CreateAggregateInput input);

    /// <summary>
    /// 编辑聚合根
    /// </summary>
    Task UpdateAggregateAsync(UpdateAggregateInput input);

    /// <summary>
    /// 删除聚合根
    /// </summary>
    Task DeleteAggregateAsync(DeleteAggregateInput input);

    /// <summary>
    /// 创建实体
    /// </summary>
    Task CreateEntityModelAsync(CreateEntityModelInput input);

    /// <summary>
    /// 编辑实体
    /// </summary>
    Task UpdateEntityModelAsync(UpdateEntityModelInput input);

    /// <summary>
    /// 删除实体
    /// </summary>
    Task DeleteEntityModelAsync(DeleteEntityModelInput input);

    /// <summary>
    /// 创建实体属性
    /// </summary>
    Task CreateEntityModelPropertyAsync(CreateEntityModelPropertyInput input);

    /// <summary>
    /// 编辑实体属性
    /// </summary>
    Task UpdateEntityModelPropertyAsync(UpdateEntityModelPropertyInput input);

    /// <summary>
    /// 删除实体属性
    /// </summary>
    Task DeleteEntityModelPropertyAsync(DeleteEntityModelPropertyInput input);

    /// <summary>
    /// 获取聚合根，结构树
    /// </summary>
    Task<List<GetEntityModelTreeOutput>> EntityModelTreeAsync(GetEntityModelTreeInput input);

    Task<List<GetEntityModelOutput>> GetAsync(GetEntityModelInput input);
}