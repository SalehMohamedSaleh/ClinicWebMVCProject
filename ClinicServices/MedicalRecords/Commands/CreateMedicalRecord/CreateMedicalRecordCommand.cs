using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.MedicalRecords.Commands.CreateMedicalRecord
{
    public record CreateMedicalRecordCommand(
         string Diagnosis,
         string Observations,
         int PatientId,
         int AppointmentId
     ) : IRequest<Unit>;
}
