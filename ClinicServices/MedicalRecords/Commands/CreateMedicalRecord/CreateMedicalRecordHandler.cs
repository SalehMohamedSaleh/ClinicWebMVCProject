using ClinicDomain.Entities;
using ClinicDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.MedicalRecords.Commands.CreateMedicalRecord
{
    public class CreateMedicalRecordHandler : IRequestHandler<CreateMedicalRecordCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public CreateMedicalRecordHandler(IUnitOfWork uow) => _uow = uow;

        public async Task<Unit> Handle(CreateMedicalRecordCommand request, CancellationToken ct)
        {
            // إنشاء كائن السجل الطبي (التحقق موجود داخل الكونستركتور في MedicalRecord.cs)
            var record = new MedicalRecord(request.Diagnosis, request.Observations, request.PatientId, request.AppointmentId);

            await _uow.MedicalRecords.AddAsync(record);
            await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}
