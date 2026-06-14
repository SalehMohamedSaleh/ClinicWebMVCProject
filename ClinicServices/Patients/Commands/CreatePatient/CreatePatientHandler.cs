using ClinicDomain.Entities;
using ClinicDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Patients.Commands.CreatePatient
{
    public class CreatePatientHandler : IRequestHandler<CreatePatientCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePatientHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(CreatePatientCommand request, CancellationToken ct)
        {
            // إنشاء كائن المريض، والـ Constructor سيقوم بعمل التحقق (Validation)
            // إذا كانت البيانات غير صحيحة، سيتم رمي استثناء (Exception) هنا
            var patient = new Patient(request.Name, request.Age, request.Phone);

            // إضافة المريض لقاعدة البيانات
            await _unitOfWork.Patients.AddAsync(patient);

            // حفظ التغييرات باستخدام UnitOfWork
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
