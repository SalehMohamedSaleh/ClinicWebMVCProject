using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Bills.Commands.DeleteBill
{
    public record DeleteBillCommand(int BillId) : IRequest<Unit>;
}
