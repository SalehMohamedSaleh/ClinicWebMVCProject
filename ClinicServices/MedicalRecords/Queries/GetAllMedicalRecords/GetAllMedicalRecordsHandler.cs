using ClinicDomain.Interfaces;
using ClinicServices.MedicalRecords.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.MedicalRecords.Queries.GetAllMedicalRecords
{
    public class GetAllMedicalRecordsHandler : IRequestHandler<GetAllMedicalRecordsQuery, IEnumerable<MedicalRecordDto>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllMedicalRecordsHandler(IUnitOfWork uow) => _uow = uow;

        public async Task<IEnumerable<MedicalRecordDto>> Handle(GetAllMedicalRecordsQuery request, CancellationToken ct)
        {
            // جلب السجلات من المستودع
            var records = await _uow.MedicalRecords.GetAllAsync();

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
