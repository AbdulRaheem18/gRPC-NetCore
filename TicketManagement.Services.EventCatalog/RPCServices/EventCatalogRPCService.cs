
using EventCatalog.gRPC;
using FOA.Application.Mapper;
using Grpc.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using TicketManagement.Services.EventCatalog.Application.Feature.Category.Queries;
using static EventCatalog.gRPC.EventCatalogService;

namespace TicketManagement.Services.EventCatalog.RPCServices;
public class EventCatalogRPCService : EventCatalogServiceBase
{
    private readonly IMediator _mediator;

    public EventCatalogRPCService(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    public override async Task<CategoriesResponse> GetAllCategories(GetCategoriesRequest request,ServerCallContext context)
    {
        var serviceResult = await _mediator.Send(new GetAllCategoriesRequest());
        var result =  gRPCMappers.Mapper.Map<List<CategoryItem>>(serviceResult);
        var response = new CategoriesResponse();
        response.Categories.AddRange(result);
        return response;
        
    }
}

