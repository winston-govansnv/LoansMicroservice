using LoansMicroservice.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoansMicroservice.Bank.DataAccess.Data.EFCore.Interface
{
    public interface IEFLoansDataRepository
    {
        Task<List<Loans>> GetLoans(string customerId);
        Task<string> AddLoan(Loans loan);
    }
}
