using ClinicServices.Prescriptions.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Prescriptions.Queries.GetPrescriptionById
{
    public record GetPrescriptionByIdQuery(int Id) : IRequest<PrescriptionDto>;
}
