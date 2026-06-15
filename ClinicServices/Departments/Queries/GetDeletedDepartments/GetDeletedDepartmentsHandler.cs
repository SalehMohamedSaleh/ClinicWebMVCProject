using ClinicDomain.Interfaces;
using ClinicServices.Departments.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Departments.Queries.GetDeletedDepartments
{
    public class GetDeletedDepartmentsHandler : IRequestHandler<GetDeletedDepartmentsQuery, IEnumerable<DepartmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeletedDepartmentsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DepartmentDto>> Handle(GetDeletedDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var deletedDepartments = await _unitOfWork.Departments.GetDeletedsAsync();

            return deletedDepartments.Select(d => new DepartmentDto(d.Id, d.Name));
        }
    }
}
