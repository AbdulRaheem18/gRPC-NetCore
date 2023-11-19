using AutoMapper;
using EventCatalog.gRPC;
using TicketManagement.Services.EventCatalog.Application.Feature.Category.Queries;
using TicketManagement.Services.EventCatalog.Core.Entities;

namespace TicketManagement.Services.EventCatalog.Application.Mapper
{
    public class gRPCCategoryProfile : Profile
    {
        public gRPCCategoryProfile()
        {
            CreateMap<GetAllCategoriesResponse, CategoryItem>().ReverseMap();
        }
    }
}
