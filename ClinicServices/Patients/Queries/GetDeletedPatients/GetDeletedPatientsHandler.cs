using ClinicDomain.Interfaces;
using ClinicServices.Patients.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Patients.Queries.GetDeletedPatients
{
    public class GetDeletedPatientsHandler : IRequestHandler<GetDeletedPatientsQuery, List<PatientDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeletedPatientsHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<List<PatientDto>> Handle(GetDeletedPatientsQuery request, CancellationToken ct)
        {
            var deletedPatients = await _unitOfWork.Patients.GetDeletedPatientsAsync();

            // تحويل الكيانات إلى DTOs
            return deletedPatients.Select(p => new PatientDto(p.Id, p.Name, p.Age, p.Phone)).ToList();
        }
    }
}
