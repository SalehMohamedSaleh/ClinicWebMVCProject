using ClinicDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Patients.Commands.UpdateDoctorPatient
{
    public class UpdatePatientContactHandler : IRequestHandler<UpdatePatientContactCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePatientContactHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdatePatientContactCommand request, CancellationToken ct)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(request.PatientId);

            if (patient == null)
                throw new KeyNotFoundException($"المريض صاحب المعرف {request.PatientId} غير موجود.");

            // استدعاء المنطق الموجود داخل كلاس الـ Patient
            patient.UpdateContactInfo(request.NewPhone);

            await _unitOfWork.CompleteAsync();
            return Unit.Value;
        }
    }
}
