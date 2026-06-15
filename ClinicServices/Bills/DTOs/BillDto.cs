using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Bills.DTOs
{
    public record BillDto(
          int Id,
          decimal Amount,
          string Currency,
          bool IsPaid,
          int AppointmentId
      );
}
