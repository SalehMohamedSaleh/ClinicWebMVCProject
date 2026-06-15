using ClinicDomain.Interfaces;
using ClinicServices.MedicalRecords.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.MedicalRecords.Queries.GetDeletedMedicalRecords
{
    public class GetDeletedMedicalRecordsHandler : IRequestHandler<GetDeletedMedicalRecordsQuery, IEnumerable<MedicalRecordDto>>
    {
        private readonly IUnitOfWork _uow;

        public GetDeletedMedicalRecordsHandler(IUnitOfWork uow) => _uow = uow;

        public async Task<IEnumerable<MedicalRecordDto>> Handle(GetDeletedMedicalRecordsQuery request, CancellationToken ct)
        {
            var deletedRecords = await _uow.MedicalRecords.GetDeletedAsync();

            return deletedRecords.Select(r => new MedicalRecordDto(
                r.Id,
                r.Diagnosis,
                r.Observations,
                r.PatientId,
                r.AppointmentId
            ));
        }
    }
}
