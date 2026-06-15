using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.MedicalRecords.DTOs
{
    public record MedicalRecordDto(int Id, string Diagnosis, string Observations, int PatientId, int AppointmentId);
}
