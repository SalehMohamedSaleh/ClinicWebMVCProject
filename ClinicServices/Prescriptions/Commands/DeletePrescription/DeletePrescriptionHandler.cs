using ClinicDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Prescriptions.Commands.DeletePrescription
{
    public class DeletePrescriptionHandler : IRequestHandler<DeletePrescriptionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePrescriptionHandler(IUnitOfWork uow) => _unitOfWork = uow;

        public async Task<Unit> Handle(DeletePrescriptionCommand request, CancellationToken ct)
        {
            var prescription = await _unitOfWork.Prescriptions.GetByIdAsync(request.Id);
            if (prescription == null) throw new KeyNotFoundException();

            prescription.Delete(); // تفعيل الحذف المنطقي من داخل الكيان
            await _unitOfWork.CompleteAsync();
            return Unit.Value;
        }
    }
}
