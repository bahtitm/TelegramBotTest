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
                            new InlineKeyboard { Text = "Services", Url=$"https://89.111.173.247/", CallbackData=$"/api/Subscriptions/forTelegram/{update.Message.Chat.Id}" },
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


    }
}
