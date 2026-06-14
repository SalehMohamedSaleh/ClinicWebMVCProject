using ClinicDomain.Interfaces;
using ClinicServices.Doctors.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Doctors.Queries.GetDoctorByI
{
    public class GetDoctorByIdHandler : IRequestHandler<GetDoctorByIdQuery, DoctorDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDoctorByIdHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<DoctorDto> Handle(GetDoctorByIdQuery request, CancellationToken ct)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(request.DoctorId);

            if (doctor == null)
                throw new KeyNotFoundException($"الطبيب صاحب المعرف {request.DoctorId} غير موجود.");

            return new DoctorDto(doctor.Id, doctor.Name, doctor.Specialization, doctor.Salary.Amount, doctor.Salary.Currency);
        }
    }
}
