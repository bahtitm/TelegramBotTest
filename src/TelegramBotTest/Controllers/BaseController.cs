using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NodeJurnalTest.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator mediator => HttpContext.RequestServices.GetService<IMediator>();
    }
}
