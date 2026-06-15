using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Appointments.Commands.UpdateAppointment
{
    public record UpdateAppointmentCommand(int AppointmentId, DateTime NewStart, DateTime NewEnd) : IRequest<Unit>;
}
