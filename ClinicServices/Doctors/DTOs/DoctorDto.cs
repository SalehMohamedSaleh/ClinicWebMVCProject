using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Doctors.DTOs
{
     public record DoctorDto(int Id, string Name, string Specialization, decimal Salary, string Currency);
    
}
