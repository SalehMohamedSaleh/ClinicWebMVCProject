using ClinicServices.Patients.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Patients.Queries.GetAllPatients
{
    public record GetAllPatientsQuery() : IRequest<List<PatientDto>>;
}
