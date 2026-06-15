using ClinicDomain.Entities;
using ClinicDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Prescriptions.Commands.CreatePrescription
{
    public class CreatePrescriptionHandler : IRequestHandler<CreatePrescriptionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePrescriptionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreatePrescriptionCommand request, CancellationToken cancellationToken)
        {
            // 1. جلب الموعد
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(request.AppointmentId);

            if (appointment == null)
                throw new KeyNotFoundException($"الموعد ذو المعرف {request.AppointmentId} غير موجود.");

            // 2. إنشاء الوصفة الطبية (الكلاس سيقوم بالتحقق من البيانات عبر الكونستركتور)
            var prescription = new Prescription(request.MedicineName, request.Dosage, request.AppointmentId);

            // 3. إضافة الوصفة للموعد عبر منطق الدومين
            appointment.AddPrescription(prescription);

            // 4. حفظ التغييرات
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
