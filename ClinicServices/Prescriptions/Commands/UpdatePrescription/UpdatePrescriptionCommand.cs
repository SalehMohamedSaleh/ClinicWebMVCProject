using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Prescriptions.Commands.UpdatePrescription
{
    public record UpdatePrescriptionCommand(int PrescriptionId, string NewDosage) : IRequest<Unit>;
}

