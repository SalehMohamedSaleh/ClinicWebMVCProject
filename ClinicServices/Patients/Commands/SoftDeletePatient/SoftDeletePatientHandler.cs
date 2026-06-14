using ClinicDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Patients.Commands.SoftDeletePatient
{
    public class SoftDeletePatientHandler : IRequestHandler<SoftDeletePatientCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SoftDeletePatientHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(SoftDeletePatientCommand request, CancellationToken ct)
        {
            // 1. جلب المريض
            var patient = await _unitOfWork.Patients.GetByIdAsync(request.PatientId);

            if (patient == null)
                throw new KeyNotFoundException($"المريض صاحب المعرف {request.PatientId} غير موجود.");
            patient.Delete(); 

            // 3. الحفظ
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
