using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Appointments.Commands.DeleteAppointment
{
    public record CancelAppointmentCommand(int AppointmentId) : IRequest<Unit>;
}
