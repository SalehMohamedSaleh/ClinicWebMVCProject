using ClinicServices.Prescriptions.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Prescriptions.Queries.GetAllPrescription
{
    public record GetAllPrescriptionsQuery() : IRequest<IEnumerable<PrescriptionDto>>;
}
