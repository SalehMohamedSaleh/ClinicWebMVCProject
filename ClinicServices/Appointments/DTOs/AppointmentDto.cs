using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Appointments.DTOs
{
    public record AppointmentDto(
        int Id,
        DateTime Start,
        DateTime End,
        string Status,
        string DoctorName,
        string PatientName);
}
