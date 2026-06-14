using ClinicDomain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Doctors.Commands.CreateDoctor
{
    public record CreateDoctorCommand(string Name, string Specialization, decimal SalaryAmount, string Currency) : IRequest<int>;
}
