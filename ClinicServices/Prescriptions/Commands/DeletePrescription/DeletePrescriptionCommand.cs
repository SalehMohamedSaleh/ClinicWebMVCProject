using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Prescriptions.Commands.DeletePrescription
{
    public record DeletePrescriptionCommand(int Id) : IRequest<Unit>;
}
