using ClinicDomain.Interfaces;
using ClinicServices.Bills.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Bills.Queries.GetDeletedBills
{
    public class GetDeletedBillsHandler : IRequestHandler<GetDeletedBillsQuery, IEnumerable<BillDto>>
    {
        private readonly IUnitOfWork _uow;

        public GetDeletedBillsHandler(IUnitOfWork uow) => _uow = uow;

        public async Task<IEnumerable<BillDto>> Handle(GetDeletedBillsQuery request, CancellationToken ct)
        {
            var deletedBills = await _uow.Bills.GetDeletedAsync();

            return deletedBills.Select(b => new BillDto(
                b.Id,
                b.Amount.Amount,
                b.Amount.Currency,
                b.IsPaid,
                b.AppointmentId
            ));
        }
    }
}
