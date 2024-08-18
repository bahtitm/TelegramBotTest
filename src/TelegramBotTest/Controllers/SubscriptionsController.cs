using Application.Features.Subscriptions.Commands.CreateSubscription;
using Application.Features.Subscriptions.Commands.DeleteSubscription;
using Application.Features.Subscriptions.Commands.UpdateSubscription;
using Application.Features.Subscriptions.Queries.GetAll;
using Application.Features.Subscriptions.Queries.GetDetail;
using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Commands.DeleteUser;
using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetDetail;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SubscriptionsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dataSource = await mediator.Send(new GetAllSubscriptionQuery());
            return Ok(dataSource.AsQueryable());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(uint id)
        {
            return Ok(await mediator.Send(new GetDetailSubscriptionQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSubscriptionCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(uint id, [FromBody] UpdateSubscriptionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest($"Check request: {id} not equals {command.Id}");
            }
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(uint id)
        {
            await mediator.Send(new DeleteSubscriptionCommand(id));
            return NoContent();
        }
    }
}
