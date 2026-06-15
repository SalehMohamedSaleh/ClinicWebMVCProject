using ClinicDomain.Interfaces;
using ClinicDomain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Bills.Commands.UpdateBill
{
    public class UpdateBillHandler : IRequestHandler<UpdateBillCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public UpdateBillHandler(IUnitOfWork uow) => _uow = uow;

        public async Task<Unit> Handle(UpdateBillCommand request, CancellationToken ct)
        {
            var bill = await _uow.Bills.GetByIdAsync(request.BillId);

            if (bill == null)
                throw new KeyNotFoundException($"الفاتورة ذات المعرف {request.BillId} غير موجودة.");

            // إنشاء الـ Value Object الجديد
            var newAmount = new Money(request.NewAmount, request.NewCurrency);

            // تحديث البيانات
            bill.Update(newAmount);

            await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}
