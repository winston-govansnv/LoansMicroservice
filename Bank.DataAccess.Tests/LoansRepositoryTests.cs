using LoansMicroservice.Bank.DataAccess;
using LoansMicroservice.Bank.DataAccess.Data.EFCore;
using LoansMicroservice.DataAccess.Data.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DataAccess
{
    [TestFixture]
    public class LoansRepositoryTests
    {
        private Loans loan_One;
        private Loans loan_Two;
        private DbContextOptions<ApplicationDBContext> options;

        public LoansRepositoryTests()
        {
            loan_One = new Loans()
            {
                LoanNumber=1007,
                CustomerId= 1,
                StartDt= DateTime.Parse("2021-09-28T01:52:04.825Z"),
                LoanType="Vehicle",
                TotalLoan=8000,
                AmountPaid=4000,
                OutstandingAmount=4000,
                CreateDt= DateTime.Now
            };


            loan_Two = new Loans()
            {
                LoanNumber = 1008,
                CustomerId = 1,
                StartDt = DateTime.Parse("2021-09-28T03:52:04.825Z"),
                LoanType = "Vehicle",
                TotalLoan = 10000,
                AmountPaid = 2000,
                OutstandingAmount = 8000,
                CreateDt = DateTime.Now
            };

        }

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<ApplicationDBContext>()
               .UseInMemoryDatabase(databaseName: "temp_Bank").Options;
        }
        
        [Test]
        [Order(1)]
        public async Task SaveLoanBooking_Loan_One_CheckTheValuesFromDatabase()
        {
            //Arrange
          

            //Act
            using (var context = new ApplicationDBContext(options))
            {
                var repository = new EFLoansDataRepository(context);
                await repository.AddLoan(loan_One);
            }

            //Assert
            using (var context = new ApplicationDBContext(options))
            {
                var loanFromDB = await context.Loans.FirstOrDefaultAsync(u =>u.LoanNumber==1007);
                Assert.AreEqual(loan_One.LoanNumber, loanFromDB.LoanNumber);
                Assert.AreEqual(loan_One.CustomerId, loanFromDB.CustomerId);
                Assert.AreEqual(loan_One.LoanType, loanFromDB.LoanType);
                Assert.AreEqual(loan_One.TotalLoan, loanFromDB.TotalLoan);
                Assert.AreEqual(loan_One.AmountPaid, loanFromDB.AmountPaid);
                Assert.AreEqual(loan_One.OutstandingAmount, loanFromDB.OutstandingAmount);
            }

        }


        [Test]
        [Order(2)]
        public async Task GetAllLoanBooking_Loan_OneAndTwo_CheckTheValuesFromDatabase()
        {
            //Arrange
            var expectedResult = new List<Loans> { loan_One, loan_Two};
           

            using (var context = new ApplicationDBContext(options))
            {
                context.Database.EnsureDeleted();
                var repository = new EFLoansDataRepository(context);
                await repository.AddLoan(loan_One);
                await repository.AddLoan(loan_Two);
            }

            //Act
            List<Loans> actualList;
            using (var context = new ApplicationDBContext(options))
            {
                
                var repository = new EFLoansDataRepository(context);
                actualList= await repository.GetAll();
            }

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualList, new LoanCompare());

        }

        private class LoanCompare : IComparer
        {
            public int Compare(object x, object y)
            {
                var loan1 = (Loans)x;
                var loan2 = (Loans)y;

                if (loan1.Id != loan2.Id)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

    }
}
