using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Bills.Commands.CreateBill
{
    public record CreateBillCommand(decimal AmountValue, string Currency, int AppointmentId) : IRequest<int>;
}
