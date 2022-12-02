using Lion.AbpSuite.EntityModels;
using Lion.AbpSuite.EntityModels.Dto;

namespace Lion.AbpSuite.Controllers;
[Route("EntityModels")]
public class EntityModelController : AbpSuiteController, IEntityModelAppService
{
    private readonly IEntityModelAppService _entityModelAppService;

    public EntityModelController(IEntityModelAppService entityModelAppService)
    {
        _entityModelAppService = entityModelAppService;
    }

    [HttpPost("PageProperty")]
    [SwaggerOperation(summary: "分页获取实体属性", Tags = new[] { "EntityModels" })]
    public Task<PagedResultDto<PageEntityModelPropertyOutput>> PagePropertyAsync(PageEntityModelInput input)
    {
        return _entityModelAppService.PagePropertyAsync(input);
    }

    [HttpPost("CreateAggregate")]
    [SwaggerOperation(summary: "新增聚合根", Tags = new[] { "EntityModels" })]
    public Task CreateAggregateAsync(CreateAggregateInput input)
    {
        return _entityModelAppService.CreateAggregateAsync(input);
    }
    [HttpPost("UpdateAggregate")]
    [SwaggerOperation(summary: "更新聚合根", Tags = new[] { "EntityModels" })]
    public Task UpdateAggregateAsync(UpdateAggregateInput input)
    {
        return _entityModelAppService.UpdateAggregateAsync(input);
    }
    [HttpPost("DeleteAggregate")]
    [SwaggerOperation(summary: "删除聚合根", Tags = new[] { "EntityModels" })]
    public Task DeleteAggregateAsync(DeleteAggregateInput input)
    {
        return _entityModelAppService.DeleteAggregateAsync(input);
    }
    [HttpPost("CreateEntityModel")]
    [SwaggerOperation(summary: "新增实体", Tags = new[] { "EntityModels" })]
    public Task CreateEntityModelAsync(CreateEntityModelInput input)
    {
        return _entityModelAppService.CreateEntityModelAsync(input);
    }
    [HttpPost("UpdateEntityModel")]
    [SwaggerOperation(summary: "更新实体", Tags = new[] { "EntityModels" })]
    public Task UpdateEntityModelAsync(UpdateEntityModelInput input)
    {
        return _entityModelAppService.UpdateEntityModelAsync(input);
    }
    [HttpPost("DeleteEntityModel")]
    [SwaggerOperation(summary: "删除实体", Tags = new[] { "EntityModels" })]
    public Task DeleteEntityModelAsync(DeleteEntityModelInput input)
    {
        return _entityModelAppService.DeleteEntityModelAsync(input);
    }
    [HttpPost("CreateEntityModelProperty")]
    [SwaggerOperation(summary: "新增实体属性", Tags = new[] { "EntityModels" })]
    public Task CreateEntityModelPropertyAsync(CreateEntityModelPropertyInput input)
    {
        return _entityModelAppService.CreateEntityModelPropertyAsync(input);
    }
    [HttpPost("UpdateEntityModelProperty")]
    [SwaggerOperation(summary: "更新实体属性", Tags = new[] { "EntityModels" })]
    public Task UpdateEntityModelPropertyAsync(UpdateEntityModelPropertyInput input)
    {
        return _entityModelAppService.UpdateEntityModelPropertyAsync(input);
    }
    [HttpPost("DeleteEntityModelProperty")]
    [SwaggerOperation(summary: "删除实体属性", Tags = new[] { "EntityModels" })]
    public Task DeleteEntityModelPropertyAsync(DeleteEntityModelPropertyInput input)
    {
        return _entityModelAppService.DeleteEntityModelPropertyAsync(input);
    }
    [HttpPost("Tree")]
    [SwaggerOperation(summary: "获取实体树", Tags = new[] { "EntityModels" })]
    public Task<List<GetEntityModelTreeOutput>> EntityModelTreeAsync(GetEntityModelTreeInput input)
    {
        return _entityModelAppService.EntityModelTreeAsync(input);
    }
    [HttpPost("Get")]
    [SwaggerOperation(summary: "获取模型数据", Tags = new[] { "EntityModels" })]
    public Task<List<GetEntityModelOutput>> GetAsync(GetEntityModelInput input)
    {
        return _entityModelAppService.GetAsync(input);
    }
}