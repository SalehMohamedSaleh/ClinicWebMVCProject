using ClinicServices.Bills.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Bills.Queries.GetAllBills
{
    public record GetAllBillsQuery() : IRequest<IEnumerable<BillDto>>;
}
