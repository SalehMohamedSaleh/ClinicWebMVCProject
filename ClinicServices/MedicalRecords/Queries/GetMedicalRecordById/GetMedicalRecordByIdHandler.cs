using ClinicDomain.Interfaces;
using ClinicServices.MedicalRecords.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.MedicalRecords.Queries.GetMedicalRecordById
{
    public class GetMedicalRecordByIdHandler : IRequestHandler<GetMedicalRecordByIdQuery, MedicalRecordDto>
    {
        private readonly IUnitOfWork _uow;

        public GetMedicalRecordByIdHandler(IUnitOfWork uow) => _uow = uow;

        public async Task<MedicalRecordDto> Handle(GetMedicalRecordByIdQuery request, CancellationToken ct)
        {
            var record = await _uow.MedicalRecords.GetByIdAsync(request.Id);

            if (record == null)
                throw new KeyNotFoundException($"السجل الطبي ذو المعرف {request.Id} غير موجود.");

            return new MedicalRecordDto(
                record.Id,
                record.Diagnosis,
                record.Observations,
                record.PatientId,
                record.AppointmentId
            );
        }
    }
}
