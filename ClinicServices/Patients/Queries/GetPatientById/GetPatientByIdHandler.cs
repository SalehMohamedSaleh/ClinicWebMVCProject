using ClinicDomain.Interfaces;
using ClinicServices.Patients.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Patients.Queries.GetPatientById
{
    public class GetPatientByIdHandler : IRequestHandler<GetPatientByIdQuery, PatientDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPatientByIdHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<PatientDto> Handle(GetPatientByIdQuery request, CancellationToken ct)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(request.PatientId);

            if (patient == null) throw new KeyNotFoundException("المريض غير موجود.");

            // تحويل الكيان إلى DTO (من الأفضل استخدام AutoMapper لاحقاً)
            return new PatientDto(patient.Id, patient.Name, patient.Age, patient.Phone);
        }
    }
}
