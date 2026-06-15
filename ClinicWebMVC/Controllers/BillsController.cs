using ClinicServices.Bills.Commands.CreateBill;
using ClinicServices.Bills.Commands.PayBill;
using ClinicServices.Bills.Queries.GetAllBills;
using ClinicServices.Bills.Queries.GetBillById;
using Microsoft.AspNetCore.Mvc;

namespace ClinicWebMVC.Controllers
{
    public class BillsController : BaseController
    {
        // عرض قائمة الفواتير
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var bills = await Mediator.Send(new GetAllBillsQuery());
            return View(bills);
        }

        // عرض تفاصيل فاتورة
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var bill = await Mediator.Send(new GetBillByIdQuery(id));
            return View("Details", bill);
        }

        // إنشاء فاتورة جديدة
        [HttpPost]
        public async Task<IActionResult> Create(CreateBillCommand command)
        {
            await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        // دفع فاتورة
        [HttpPost]
        public async Task<IActionResult> Pay(int id)
        {
            await Mediator.Send(new PayBillCommand(id));
            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
