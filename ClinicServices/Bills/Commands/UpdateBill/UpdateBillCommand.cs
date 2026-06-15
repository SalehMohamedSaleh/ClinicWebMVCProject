using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Bills.Commands.UpdateBill
{
    public record UpdateBillCommand(int BillId, decimal NewAmount, string NewCurrency) : IRequest<Unit>;
}
