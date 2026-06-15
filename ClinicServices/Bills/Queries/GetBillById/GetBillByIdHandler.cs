using ClinicDomain.Interfaces;
using ClinicServices.Bills.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Bills.Queries.GetBillById
{
    public class GetBillByIdHandler : IRequestHandler<GetBillByIdQuery, BillDto>
    {
        private readonly IUnitOfWork _uow;

        public GetBillByIdHandler(IUnitOfWork uow) => _uow = uow;

        public async Task<BillDto> Handle(GetBillByIdQuery request, CancellationToken ct)
        {
            // جلب الفاتورة من خلال المستودع
            var bill = await _uow.Bills.GetByIdAsync(request.Id);

            if (bill == null)
                throw new KeyNotFoundException($"الفاتورة ذات المعرف {request.Id} غير موجودة.");

            // تحويل الكيان إلى DTO لعرض البيانات
            return new BillDto(
                bill.Id,
                bill.Amount.Amount,
                bill.Amount.Currency,
                bill.IsPaid,
                bill.AppointmentId
            );
        }
    }
}
