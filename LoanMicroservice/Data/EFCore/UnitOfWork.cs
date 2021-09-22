using LoansMicroservice.Data.EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoansMicroservice.Data.EFCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;

        public UnitOfWork(ApplicationDBContext context )
        {
           
            _context = context;

            eFLoansDataRepository = new EFLoansDataRepository(_context);
        }

        public IEFLoansDataRepository eFLoansDataRepository { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
