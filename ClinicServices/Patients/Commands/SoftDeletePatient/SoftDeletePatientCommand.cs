using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Patients.Commands.SoftDeletePatient
{
    public record SoftDeletePatientCommand(int PatientId) : IRequest<Unit>;
}
