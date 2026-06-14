using ClinicServices.Patients.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Patients.Queries.GetPatientById
{
    public record GetPatientByIdQuery(int PatientId) : IRequest<PatientDto>;

}
