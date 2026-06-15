using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.MedicalRecords.Commands.UpdateMedicalRecord
{
    public record UpdateMedicalRecordCommand(int Id, string NewDiagnosis, string NewObservations) : IRequest<Unit>;
}
