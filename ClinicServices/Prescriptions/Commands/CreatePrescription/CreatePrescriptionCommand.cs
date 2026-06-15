using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Prescriptions.Commands.CreatePrescription
{
    public record CreatePrescriptionCommand(
        string MedicineName,
        string Dosage,
        int AppointmentId
    ) : IRequest<Unit>;
}
