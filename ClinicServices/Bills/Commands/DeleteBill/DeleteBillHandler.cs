using ClinicDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Bills.Commands.DeleteBill
{
    public class DeleteBillHandler : IRequestHandler<DeleteBillCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public DeleteBillHandler(IUnitOfWork uow) => _uow = uow;

        public async Task<Unit> Handle(DeleteBillCommand request, CancellationToken ct)
        {
            var bill = await _uow.Bills.GetByIdAsync(request.BillId);

            if (bill == null)
                throw new KeyNotFoundException($"الفاتورة ذات المعرف {request.BillId} غير موجودة.");

            // حذف الفاتورة من المستودع
            bill.Delete(); // تأكد من أن هذا هو الأسلوب الصحيح لحذف الفاتورة في مستودعك

            // حفظ التغييرات
            await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}
