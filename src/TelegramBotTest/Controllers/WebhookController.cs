using Application.Features.Subscriptions.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

            logger.LogCritical("update");
            var json = JsonSerializer.Serialize(update);
            logger.LogCritical(json);
            if (update.CallbackQuery is not null && update?.Message?.Chat is not null)
            {
                ///return Redirect(update?.CallbackQuery?.Data ?? "/");

                var dataSource = await mediator.Send(new GetAllSubscriptionQuery());
                var inlineKeyboards = new List<List<InlineKeyboard>>();
                foreach (var item in dataSource)
                {
                    var t = new List<InlineKeyboard>() { new InlineKeyboard { Text = item.Name, CallbackData = "1" } };
                    inlineKeyboards.Add(t);
                }
                var backButton = new List<InlineKeyboard>() { new InlineKeyboard { Text = "Назад", CallbackData = "1" } };
                inlineKeyboards.Add(backButton);




                var message1 = new MessageForSend
                {
                    ChatId = update.Message.Chat.Id,
                    Text = "Services",
                    ReplyMarkup = new ReplyMarkup
                    {
                        InlineKeyboard = inlineKeyboards,
                    },

                };
                
                try
                {

                    await telegramApiService.SendMessageToBot(message1);
                    logger.LogCritical("MessageCL");
                    var messageJsonCL = JsonSerializer.Serialize(message1);
                    logger.LogCritical(messageJsonCL);
                }
                catch (Exception e)
                {

                    logger.LogCritical(e.Message);

                }

            }


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
            
            
            return NoContent();
        }


    }
}
