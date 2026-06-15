using ClinicDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.MedicalRecords.Commands.DeleteMedicalRecord
{
    public class DeleteMedicalRecordHandler : IRequestHandler<DeleteMedicalRecordCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public DeleteMedicalRecordHandler(IUnitOfWork uow) => _uow = uow;

        public async Task<Unit> Handle(DeleteMedicalRecordCommand request, CancellationToken ct)
        {
            var record = await _uow.MedicalRecords.GetByIdAsync(request.Id);
            if (record == null) throw new KeyNotFoundException("السجل الطبي غير موجود.");

            // تنفيذ الحذف المنطقي الموجود في الكيان
            record.Delete();

            await _uow.CompleteAsync();
            return Unit.Value;
        }
    }
}
