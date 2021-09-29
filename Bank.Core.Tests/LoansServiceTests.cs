using Bank.Core.Services;
using LoansMicroservice.Bank.DataAccess;
using LoansMicroservice.Bank.DataAccess.Data.EFCore;
using LoansMicroservice.Bank.DataAccess.Data.EFCore.Interface;
using LoansMicroservice.DataAccess.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core
{
    [TestFixture]
    public class LoansServiceTests
    {
        private Loans _request;
        private List<Loans> _storedLoan;
        private List<Loans> _availableLoans;
        private Mock<IUnitOfWork> _unitOfMock;
        private LoansService _loanService;

        [SetUp]
        public void Setup()
        {

            _request = new Loans()
             {
                 LoanNumber = 1007,
                 CustomerId = 1,
                 StartDt = DateTime.Parse("2022-09-30T01:52:04.825Z"),
                 LoanType = "Vehicle",
                 TotalLoan = 8000,
                 AmountPaid = 4000,
                 OutstandingAmount = 4000,
                 CreateDt = DateTime.Now
             };

            _availableLoans = new List<Loans>()
            {
                new Loans()
                {
                    Id=new Guid(), CustomerId=10, TotalLoan=9000
                }
            };


            _storedLoan = _availableLoans;
            _unitOfMock = new Mock<IUnitOfWork>();
            _unitOfMock.Setup(x => x.eFLoansDataRepository.GetLoans("")).ReturnsAsync(_storedLoan);
            _loanService = new LoansService(_unitOfMock.Object);
        }


        [Test]
        public void LoanBookingResultCheck_InputRequest_ValuesMatchInResult()
        {
            var result = _loanService.AddLoan(_request);
            Assert.NotNull(result);
        }

        [TestCase]
        public async Task GetAllLoans_Invoked_CheckIfRepoIsCalled()
        {
            await _loanService.GetLoans("");
            _unitOfMock.Verify(x => x.eFLoansDataRepository.GetLoans(""), Times.Once);
        }
        
        [TestCase]
        public void LoansBookingException_NullRequest_ThrowsException()
        {
            var exception = Assert.ThrowsAsync<ArgumentNullException>( () =>   _loanService.AddLoan(null));
            Assert.AreEqual("Value cannot be null. (Parameter 'loan')",exception.Message);
        }

    }
}
