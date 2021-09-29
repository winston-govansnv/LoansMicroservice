using LoansMicroservice.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Services.IServices
{
    public interface ILoansService
    {
        Task<List<Loans>> GetLoans(string customerId);
        Task<string> AddLoan(Loans loan);
    }
}
