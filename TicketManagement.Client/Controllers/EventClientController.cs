using EventCatalog.gRPC;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using static EventCatalog.gRPC.EventCatalogService;

namespace TicketManagement.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventClientController : Controller
    {
        private readonly string _serviceURL;

        public EventClientController(IConfiguration IConfig)
        {
            _serviceURL = IConfig["ServiceURL"];
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            //calling grpc client 

            var channel = GrpcChannel.ForAddress(_serviceURL);
            var client = new EventCatalogServiceClient(channel);
            var request = new GetCategoriesRequest();
            var response = client.GetAllCategories(request);
            return Ok(response);
        }
    }
}
