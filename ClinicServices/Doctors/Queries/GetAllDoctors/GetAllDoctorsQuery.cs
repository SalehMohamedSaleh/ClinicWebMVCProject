using ClinicServices.Doctors.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Doctors.Queries.GetAllDoctors
{
    public record GetAllDoctorsQuery() : IRequest<IEnumerable<DoctorDto>>;
}
