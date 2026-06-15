using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicWebMVC.Controllers
{
    // نجعله Abstract لأنه كلاس قاعدي لا يُستخدم مباشرة
    public abstract class BaseController : Controller
    {
        private IMediator? _mediator;

        // نستخدم HttpContext.RequestServices للحصول على الـ Mediator
        // هذا يقلل من تكرار كتابة الـ Constructor في كل كنترولر
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
