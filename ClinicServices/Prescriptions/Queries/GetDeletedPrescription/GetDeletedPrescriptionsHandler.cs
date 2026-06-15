using ClinicDomain.Interfaces;
using ClinicServices.Prescriptions.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Prescriptions.Queries.GetDeletedPrescription
{
    public class GetDeletedPrescriptionsHandler : IRequestHandler<GetDeletedPrescriptionsQuery, IEnumerable<PrescriptionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeletedPrescriptionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PrescriptionDto>> Handle(GetDeletedPrescriptionsQuery request, CancellationToken cancellationToken)
        {
            // جلب الوصفات المحذوفة
            var deletedPrescriptions = await _unitOfWork.Prescriptions.GetDeletedAsync();

            // التحويل إلى DTO
            return deletedPrescriptions.Select(p => new PrescriptionDto(
                p.Id,
                p.MedicineName,
                p.Dosage,
                p.AppointmentId
            ));
        }
    }
}
