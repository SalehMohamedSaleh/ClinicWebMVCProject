using ClinicDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Prescriptions.Commands.UpdatePrescription
{
    public class UpdatePrescriptionHandler : IRequestHandler<UpdatePrescriptionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePrescriptionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdatePrescriptionCommand request, CancellationToken cancellationToken)
        {
            // 1. جلب الوصفة من المستودع
            var prescription = await _unitOfWork.Prescriptions.GetByIdAsync(request.PrescriptionId);

            if (prescription == null)
                throw new KeyNotFoundException($"الوصفة الطبية ذات المعرف {request.PrescriptionId} غير موجودة.");

            // 2. تحديث الجرعة (تغليف المنطق داخل الكيان)
            prescription.ChangeDosage(request.NewDosage);

            // 3. حفظ التغييرات
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
