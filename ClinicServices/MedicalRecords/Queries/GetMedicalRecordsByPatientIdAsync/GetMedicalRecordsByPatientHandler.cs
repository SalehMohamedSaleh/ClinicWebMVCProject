using ClinicDomain.Interfaces;
using ClinicServices.MedicalRecords.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.MedicalRecords.Queries.GetMedicalRecordsByPatientIdAsync
{
    public class GetMedicalRecordsByPatientHandler : IRequestHandler<GetMedicalRecordsByPatientQuery, IEnumerable<MedicalRecordDto>>
    {
        private readonly IUnitOfWork _uow;

        public GetMedicalRecordsByPatientHandler(IUnitOfWork uow) => _uow = uow;

        public async Task<IEnumerable<MedicalRecordDto>> Handle(GetMedicalRecordsByPatientQuery request, CancellationToken ct)
        {
            // استدعاء الميثود من المستودع
            var records = await _uow.MedicalRecords.GetByPatientIdAsync(request.PatientId);

            // التحويل إلى DTO
            return records.Select(r => new MedicalRecordDto(
                r.Id,
                r.Diagnosis,
                r.Observations,
                r.PatientId,
                r.AppointmentId
            ));
        }
    }
}
