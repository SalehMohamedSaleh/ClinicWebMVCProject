using ClinicDomain.Entities;
using ClinicDomain.Interfaces;
using ClinicDomain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServices.Bills.Commands.CreateBill
{
    // ClinicServices/Bills/Commands/CreateBill/CreateBillHandler.cs
    public class CreateBillHandler : IRequestHandler<CreateBillCommand, int>
    {
        private readonly IUnitOfWork _uow;
        public CreateBillHandler(IUnitOfWork uow) => _uow = uow;

        public async Task<int> Handle(CreateBillCommand request, CancellationToken ct)
        {
            var money = new Money(request.AmountValue, request.Currency);
            var bill = new Bill(money, request.AppointmentId);

            await _uow.Bills.AddAsync(bill);
            await _uow.CompleteAsync();
            return bill.Id;
        }
    }
}
