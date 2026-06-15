using ClinicDomain.Interfaces;
using ClinicServices.Appointments.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Appointments.Queries.GetAllAppointments
{
    public class GetAppointmentsByDoctorHandler : IRequestHandler<GetAppointmentsByDoctorQuery, IEnumerable<AppointmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAppointmentsByDoctorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AppointmentDto>> Handle(GetAppointmentsByDoctorQuery request, CancellationToken cancellationToken)
        {
            // استخدام الميثود المخصصة للطبيب من الـ Repository
            var appointments = await _unitOfWork.Appointments.GetAllByDoctorIdAsync(request.DoctorId);

            // تحويل النتائج إلى DTOs
            return appointments.Select(a => new AppointmentDto(
                a.Id,
                a.Date.Start,
                a.Date.End,
                a.Status.ToString(),
                a.Doctor?.Name ?? "N/A", // التعامل مع القيم الفارغة في حال عدم التضمين
                a.Patient?.Name ?? "N/A"
            ));
        }
    }
}
