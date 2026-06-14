using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Doctors.Commands.UpdateDoctorSalary
{
    public record UpdateDoctorSalaryCommand(int DoctorId, decimal NewSalary, string Currency) : IRequest;
}
