using ClinicDomain.Interfaces;
using ClinicServices.Departments.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDepartmentByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            // 1. جلب القسم من المستودع
            var department = await _unitOfWork.Departments.GetByIdAsync(request.Id);

            // 2. التحقق من وجود القسم (إرجاع خطأ 404 في الـ API لاحقاً)
            if (department == null)
                throw new KeyNotFoundException($"القسم ذو المعرف {request.Id} غير موجود.");

            // 3. تحويل الكيان إلى DTO وإرجاعه
            return new DepartmentDto(department.Id, department.Name);
        }
    }
}
