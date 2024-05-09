using Applictaion.Order;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        ISender _mediator;
        public OrderController(ISender mediator)
        {
                _mediator= mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
