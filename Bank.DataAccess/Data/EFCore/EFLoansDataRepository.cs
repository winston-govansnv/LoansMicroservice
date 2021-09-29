
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using LoansMicroservice.Bank.DataAccess.Data.EFCore.Interface;
using LoansMicroservice.DataAccess.Data.Models;

namespace LoansMicroservice.Bank.DataAccess.Data.EFCore
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
            List<Loans> list = null;
            list = await context.Loans.Where(x => x.Id == new Guid(customerId)).ToListAsync();
            if (list == null) list = new List<Loans>();

            return list;
        }
    }
}
