using LoansMicroservice.Data.EFCore.Interface;
using LoansMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LoansMicroservice.Data.EFCore
{
    public class EFLoansDataRepository : EfCoreRepository<Loans, ApplicationDBContext>, IEFLoansDataRepository
    {
        private readonly ApplicationDBContext context;
        public EFLoansDataRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<string> AddLoan(Loans loan)
        {
            var obj = await context.Loans.AddAsync(loan);
            await context.SaveChangesAsync();

            return obj.Entity.Id.ToString();
        }

        public async Task<List<Loans>> GetLoans(string customerId)
        {
            var list = await context.Loans.Where(x => x.Id == new Guid(customerId)).ToListAsync();
            return list;
        }
    }
}
