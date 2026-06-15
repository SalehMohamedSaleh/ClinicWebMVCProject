using ClinicDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.MedicalRecords.Commands.UpdateMedicalRecord
{
    public class UpdateMedicalRecordHandler : IRequestHandler<UpdateMedicalRecordCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public UpdateMedicalRecordHandler(IUnitOfWork uow) => _uow = uow;

        public async Task<Unit> Handle(UpdateMedicalRecordCommand request, CancellationToken ct)
        {
            var record = await _uow.MedicalRecords.GetByIdAsync(request.Id);

            if (record == null)
                throw new KeyNotFoundException($"السجل الطبي ذو المعرف {request.Id} غير موجود.");

            // تحديث البيانات باستخدام منطق الكيان
            record.Update(request.NewDiagnosis, request.NewObservations);

            await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}
