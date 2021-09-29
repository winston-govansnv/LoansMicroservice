using Bank.Core.Services.IServices;
using LoansMicroservice.Bank.DataAccess.Data.EFCore;
using LoansMicroservice.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Services
{
    public class LoansService : ILoansService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoansService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        public async Task<string> AddLoan(Loans loan)
        {
            if (loan == null)
            {
                throw new ArgumentNullException(nameof(loan));
            }

            var obj = await _unitOfWork.eFLoansDataRepository.AddLoan(loan);
            return obj;
        }

        public async Task<List<Loans>> GetLoans(string customerId)
        {
            var loans = await _unitOfWork.eFLoansDataRepository.GetLoans(customerId);
            return loans;
        }
    }
}
