using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradingStaking.Services;

namespace NodeJurnalTest.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator mediator => HttpContext.RequestServices.GetService<IMediator>();
        protected TelegramApiService telegramApiService=> HttpContext.RequestServices.GetService<TelegramApiService>();
    }
}
