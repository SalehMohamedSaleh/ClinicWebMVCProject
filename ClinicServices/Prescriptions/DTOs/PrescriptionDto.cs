using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Prescriptions.DTOs
{
    public record PrescriptionDto(int Id, string MedicineName, string Dosage, int AppointmentId);
}
