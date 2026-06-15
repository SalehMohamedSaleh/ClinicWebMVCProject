using ClinicServices.Bills.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Bills.Queries.GetDeletedBills
{
    public record GetDeletedBillsQuery() : IRequest<IEnumerable<BillDto>>;
}
