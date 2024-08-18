using Application.Features.Subscriptions.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TelegramBotTest.Services;

namespace TelegramBotTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class WebhookController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            if (update?.Message?.Text == "/start")
            {
                var inlineKeyboards = new List<List<InlineKeyboard>>
                    {
                        new List<InlineKeyboard>{
                            new InlineKeyboard { Text = "Services", CallbackData=$"/api/Subscriptions/forTelegram/{update.Message.Chat.Id}" },
                            new InlineKeyboard { Text = "Personal account", CallbackData = "2" }
                        }
                    };
                var message = new MessageForSend
                {
                    ChatId = update.Message.Chat.Id,
                    Text = "Menyu",
                    ReplyMarkup = new ReplyMarkup
                    {
                        InlineKeyboard = inlineKeyboards,



                    },

                };
                await telegramApiService.SendMessageToBot(message);
                logger.LogCritical("Message");
                var messageJson = JsonSerializer.Serialize(message);
                logger.LogCritical(messageJson);
            }
            logger.LogCritical("update");
            var json = JsonSerializer.Serialize(update);
            logger.LogCritical(json);
            
            return NoContent();
        }




        [HttpGet("/api/Subscriptions/forTelegram/{chartId}")]
        public async Task GetforTelegram(long chartId)
        {
            logger.LogCritical($"forTelegram/{chartId}");
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
            var json = JsonSerializer.Serialize(message);
            logger.LogCritical(json);
            try
            {

                await telegramApiService.SendMessageToBot(message);
            }
            catch (Exception e)
            {

                logger.LogCritical(e.Message);

            }



        }


    }
}
