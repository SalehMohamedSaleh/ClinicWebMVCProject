using ClinicDomain.Interfaces;
using ClinicServices.Prescriptions.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Prescriptions.Queries.GetAllPrescription
{
    public class GetAllPrescriptionsHandler : IRequestHandler<GetAllPrescriptionsQuery, IEnumerable<PrescriptionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPrescriptionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PrescriptionDto>> Handle(GetAllPrescriptionsQuery request, CancellationToken cancellationToken)
        {
            // جلب الوصفات من المستودع
            var prescriptions = await _unitOfWork.Prescriptions.GetAllAsync();

            // التحويل إلى DTO
            return prescriptions.Select(p => new PrescriptionDto(
                p.Id,
                p.MedicineName,
                p.Dosage,
                p.AppointmentId
            ));
        }
    }
}
