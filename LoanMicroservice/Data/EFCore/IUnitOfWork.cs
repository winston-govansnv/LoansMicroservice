using LoansMicroservice.Data.EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoansMicroservice.Data.EFCore
{
    public interface IUnitOfWork : IDisposable
    {
        IEFLoansDataRepository eFLoansDataRepository { get; }
       
        int Complete();
    }
}
