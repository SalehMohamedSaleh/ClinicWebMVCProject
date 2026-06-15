using ClinicDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Bills.Commands.PayBill
{
    public class PayBillHandler : IRequestHandler<PayBillCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public PayBillHandler(IUnitOfWork uow) => _uow = uow;

        public async Task<Unit> Handle(PayBillCommand request, CancellationToken ct)
        {
            // 1. جلب الفاتورة من المستودع
            var bill = await _uow.Bills.GetByIdAsync(request.BillId);

            if (bill == null)
                throw new KeyNotFoundException($"الفاتورة ذات المعرف {request.BillId} غير موجودة.");

            // 2. تنفيذ منطق الدفع داخل الكيان
            // هذه الميثود تتحقق من حالة IsPaid وتغيرها
            bill.MarkAsPaid();

            // 3. حفظ التغييرات في قاعدة البيانات
            await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}
