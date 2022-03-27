using Microsoft.AspNetCore.Mvc;


namespace Sandbox.RabbitMQ.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;        


        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //_logger.LogInformation($"Sending messages with {typeof(IProducingService)}.");
            var message = new { message = "text" };
            //await _producingService.SendAsync(message, "consumption.exchange", "routing.key");
            return Ok(message);
        }

        //private readonly IOrderDbContext _context;
        //private readonly IMessageProducer _messagePublisher;

        //public OrdersController(IOrderDbContext context, IMessageProducer messagePublisher)
        //{
        //    _context = context;
        //    _messagePublisher = messagePublisher;
        //}
    }
}
