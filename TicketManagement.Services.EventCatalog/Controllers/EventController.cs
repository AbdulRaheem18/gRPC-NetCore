using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TicketManagement.Services.EventCatalog.Application.Feature.Category.Queries;
using TicketManagement.Services.EventCatalog.Application.Feature.Event.Queries.CategoriesByEventId;
using TicketManagement.Services.EventCatalog.Application.Feature.Event.Queries.CategoriesById;
using TicketManagement.Services.EventCatalog.Core.Repositories;

namespace TicketManagement.Services.EventCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("GetEventByCategoryId")]
        public async Task<ActionResult> Get([FromBody] GetEventByCategoryIdRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("GetEventById")]
        public async Task<ActionResult> GetById([FromBody] GetEventByIdRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
