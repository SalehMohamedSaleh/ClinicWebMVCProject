using ClinicDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDepartmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            // 1. جلب القسم
            var department = await _unitOfWork.Departments.GetByIdAsync(request.Id);

            if (department == null)
                throw new KeyNotFoundException($"القسم ذو المعرف {request.Id} غير موجود.");

            // 2. تحديث الاسم باستخدام منطق الكيان
            department.UpdateName(request.NewName);

            // 3. حفظ التغييرات
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
