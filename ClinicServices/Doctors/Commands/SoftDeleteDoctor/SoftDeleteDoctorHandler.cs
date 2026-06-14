using ClinicDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Doctors.Commands.SoftDeleteDoctor
{
    public class SoftDeleteDoctorHandler : IRequestHandler<SoftDeleteDoctorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        // ملاحظة: لا تقم بحقن CancellationToken في الـ Constructor، 
        // هو يأتي فقط في ميثود Handle
        public SoftDeleteDoctorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SoftDeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            // الآن الميثود تطابق الإنترفيس تماماً ولن يظهر خطأ
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(request.DoctorId);

            if (doctor == null)
                throw new KeyNotFoundException($"الطبيب صاحب المعرف {request.DoctorId} غير موجود.");

            doctor.Delete();

            await _unitOfWork.CompleteAsync();
            return Unit.Value;
        }
    }
}
