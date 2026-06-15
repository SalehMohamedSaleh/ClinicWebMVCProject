using ClinicDomain.Interfaces;
using ClinicServices.Bills.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Bills.Queries.GetAllBills
{
    public class GetAllBillsHandler : IRequestHandler<GetAllBillsQuery, IEnumerable<BillDto>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllBillsHandler(IUnitOfWork uow) => _uow = uow;

        public async Task<IEnumerable<BillDto>> Handle(GetAllBillsQuery request, CancellationToken ct)
        {
            var bills = await _uow.Bills.GetAllAsync();

            return bills.Select(b => new BillDto(
                b.Id,
                b.Amount.Amount,
                b.Amount.Currency,
                b.IsPaid,
                b.AppointmentId
            ));
        }
    }
}
