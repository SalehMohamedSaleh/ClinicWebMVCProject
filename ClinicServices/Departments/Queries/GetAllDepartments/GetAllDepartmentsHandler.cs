using ClinicDomain.Interfaces;
using ClinicServices.Departments.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentsHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<DepartmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDepartmentsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            // جلب الأقسام من المستودع
            var departments = await _unitOfWork.Departments.GetAllAsync();

            // التحويل إلى DTO
            return departments.Select(d => new DepartmentDto(d.Id, d.Name));
        }
    }
}
