using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Appointments.Commands.CreateAppointment
{
    public record CreateAppointmentCommand(
          DateTime StartTime,
          DateTime EndTime,
          int DoctorId,
          int PatientId
      ) : IRequest<Unit>;
}
