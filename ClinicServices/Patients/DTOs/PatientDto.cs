using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Patients.DTOs
{
    public record PatientDto(
         int Id,
         string Name,
         int Age,
         string Phone
     );
}
