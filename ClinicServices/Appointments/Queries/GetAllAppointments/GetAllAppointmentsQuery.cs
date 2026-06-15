using ClinicServices.Appointments.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Appointments.Queries.GetAllAppointments
{
    public record GetAppointmentsByDoctorQuery(int DoctorId) : IRequest<IEnumerable<AppointmentDto>>;
}
