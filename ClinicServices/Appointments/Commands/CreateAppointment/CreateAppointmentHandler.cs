using ClinicDomain.Interfaces;
using ClinicDomain.Services;
using ClinicDomain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentHandler : IRequestHandler<CreateAppointmentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppointmentScheduler _scheduler;

        public CreateAppointmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _scheduler = new AppointmentScheduler();
        }

        public async Task<Unit> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(request.DoctorId);
            var patient = await _unitOfWork.Patients.GetByIdAsync(request.PatientId);

            if (doctor == null || patient == null)
                throw new KeyNotFoundException("الطبيب أو المريض غير موجود.");

            var timeRange = new TimeRange(request.StartTime, request.EndTime);
            _scheduler.Schedule(doctor, patient, timeRange);

            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
