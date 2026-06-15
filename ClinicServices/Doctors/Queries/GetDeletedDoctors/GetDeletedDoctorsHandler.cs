using ClinicDomain.Interfaces;
using ClinicServices.Doctors.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Doctors.Queries.GetDeletedDoctors
{
    public class GetDeletedDoctorsHandler : IRequestHandler<GetDeletedDoctorsQuery, IEnumerable<DoctorDto>>
    {
        private readonly IUnitOfWork _uow;

        public GetDeletedDoctorsHandler(IUnitOfWork uow) => _uow = uow;

        public async Task<IEnumerable<DoctorDto>> Handle(GetDeletedDoctorsQuery request, CancellationToken ct)
        {
            var deletedDoctors = await _uow.Doctors.GetDeletedAsync();

            return deletedDoctors.Select(d => new DoctorDto(
                d.Id,
                d.Name,
                d.Specialization,
                d.Salary.Amount, // الوصول لقيمة الراتب من الـ Value Object
                d.Salary.Currency.ToString()
            ));
        }
    }
}
