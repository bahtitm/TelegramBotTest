using Application.Features.Subscriptions.Commands.CreateSubscription;
using Application.Features.Subscriptions.Commands.DeleteSubscription;
using Application.Features.Subscriptions.Commands.UpdateSubscription;
using Application.Features.Subscriptions.Queries.GetAll;
using Application.Features.Subscriptions.Queries.GetDetail;
using Microsoft.AspNetCore.Mvc;
using TelegramBotTest.Services;

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
        [HttpGet("forTelegram/{chartId}")]
        public async Task GetforTelegram(long chartId)
        {

            var dataSource = await mediator.Send(new GetAllSubscriptionQuery());

            var inlineKeyboards = new List<List<InlineKeyboard>>();
            foreach (var item in dataSource)
            {
                var t = new List<InlineKeyboard>() { new InlineKeyboard { Text = item.Name, CallbackData = "1" } };
                inlineKeyboards.Add(t);
            }
            var backButton = new List<InlineKeyboard>() { new InlineKeyboard { Text = "Назад", CallbackData = "1" } };
            inlineKeyboards.Add(backButton);
           


           
                var message = new MessageForSend
                {
                    ChatId = chartId,
                    Text = "Services",
                    ReplyMarkup = new ReplyMarkup
                    {
                        InlineKeyboard = inlineKeyboards,



                    },

                };
               await telegramApiService.SendMessageToBot(message);
           

            
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
