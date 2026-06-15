using ClinicServices.Appointments.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Appointments.Queries.GetAppointmentById
{
    public record GetAppointmentByIdQuery(int AppointmentId) : IRequest<AppointmentDto>;
}
