using ClinicServices.Departments.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Departments.Queries.GetDeletedDepartments
{
    public record GetDeletedDepartmentsQuery() : IRequest<IEnumerable<DepartmentDto>>;
}
