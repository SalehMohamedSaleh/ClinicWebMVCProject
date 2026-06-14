using ClinicDomain.Interfaces;
using ClinicServices.Doctors.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Doctors.Queries.GetAllDoctors
{
    public class GetAllDoctorsHandler : IRequestHandler<GetAllDoctorsQuery, IEnumerable<DoctorDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDoctorsHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<DoctorDto>> Handle(GetAllDoctorsQuery request, CancellationToken ct)
        {
            var doctors = await _unitOfWork.Doctors.GetAllAsync();

            return doctors.Select(d => new DoctorDto(d.Id, d.Name, d.Specialization, d.Salary.Amount, d.Salary.Currency));
        }
    }
}
