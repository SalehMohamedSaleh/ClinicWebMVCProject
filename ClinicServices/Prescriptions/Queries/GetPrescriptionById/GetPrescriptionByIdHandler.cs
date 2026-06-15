using ClinicDomain.Interfaces;
using ClinicServices.Prescriptions.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Prescriptions.Queries.GetPrescriptionById
{
    public class GetPrescriptionByIdHandler : IRequestHandler<GetPrescriptionByIdQuery, PrescriptionDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPrescriptionByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PrescriptionDto> Handle(GetPrescriptionByIdQuery request, CancellationToken cancellationToken)
        {
            // 1. جلب الوصفة من المستودع
            var prescription = await _unitOfWork.Prescriptions.GetByIdAsync(request.Id);

            // 2. التحقق من وجود الوصفة
            if (prescription == null)
                throw new KeyNotFoundException($"الوصفة الطبية ذات المعرف {request.Id} غير موجودة.");

            // 3. تحويل الكيان إلى DTO وإرجاعه
            return new PrescriptionDto(
                prescription.Id,
                prescription.MedicineName,
                prescription.Dosage,
                prescription.AppointmentId
            );
        }
    }
}
