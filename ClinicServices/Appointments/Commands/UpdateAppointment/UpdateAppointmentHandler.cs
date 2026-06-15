using ClinicDomain.Interfaces;
using ClinicDomain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentHandler : IRequestHandler<UpdateAppointmentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAppointmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            // 1. جلب الموعد
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(request.AppointmentId);

            if (appointment == null)
                throw new KeyNotFoundException($"الموعد ذو المعرف {request.AppointmentId} غير موجود.");

            // 2. تحديث التاريخ (استخدام الـ Value Object)
            var newDate = new TimeRange(request.NewStart, request.NewEnd);

            // نفترض وجود ميثود Update في كيان Appointment أو نقوم بتعديل الخصائص مباشرة 
            // إذا كان الـ Domain يسمح بذلك. يفضل إضافة ميثود Update في الكيان للالتزام بالـ Encapsulation
            appointment.UpdateDate(newDate);

            // 3. حفظ التغييرات
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
