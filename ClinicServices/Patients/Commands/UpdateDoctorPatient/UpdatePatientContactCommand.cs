using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Patients.Commands.UpdateDoctorPatient
{
    public record UpdatePatientContactCommand(int PatientId, string NewPhone) : IRequest<Unit>;
}
