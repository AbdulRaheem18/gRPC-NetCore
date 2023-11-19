using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketManagement.Services.EventCatalog.Application.Feature.Category.Queries;

namespace TicketManagement.Services.EventCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllCategories")]
        public async Task<ActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllCategoriesRequest());
            return Ok(result);
        }
    }
}
