using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Bills.Commands.PayBill
{
    public record PayBillCommand(int BillId) : IRequest<Unit>;
}
