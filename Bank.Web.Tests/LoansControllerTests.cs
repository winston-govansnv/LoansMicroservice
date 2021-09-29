using Bank.Core.Services.IServices;
using LoansMicroservice.Controllers;
using LoansMicroservice.Logger;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Web
{
    [TestFixture]
    public class LoansControllerTests
    {
        private Mock<ILoggerManager> _loggerManager;
        private Mock<ILoansService> _loanService;
        private LoansController _loansController;

        [SetUp]
        public void Setup()
        {
            _loggerManager = new Mock<ILoggerManager>();
            _loanService = new Mock<ILoansService>();
            _loansController = new LoansController(_loanService.Object, _loggerManager.Object);

        }

        [Test]
        public async Task GetLoans_CallRequest_VerifyGetLoansInvoked()
        {
            await _loansController.GetByCustomerId("");
            _loanService.Verify(x => x.GetLoans(""), Times.Once);
        }

        [Test]
        public async Task AddLoanCheck_ModelStateInvalid_ReturnError()
        {
            _loansController.ModelState.AddModelError("test", "test");
            var result = await _loansController.Post(new LoansMicroservice.DataAccess.Data.Models.Loans());
         
            Assert.AreEqual("Microsoft.AspNetCore.Mvc.BadRequestObjectResult", result.Result.ToString());
        }
    }
}
