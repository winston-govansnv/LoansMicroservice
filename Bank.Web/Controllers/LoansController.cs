using Bank.Core.Services.IServices;
using LoansMicroservice.DataAccess.Data.Models;
using LoansMicroservice.Logger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoansMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoansService loansService;
        private readonly ILoggerManager loggerManager;

        public LoansController(ILoansService loansService, ILoggerManager loggerManager)
        {
            this.loansService = loansService;
            this.loggerManager = loggerManager;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Loans>> GetByCustomerId(string Id)
        {
            var loans = await loansService.GetLoans(Id);
            return Ok(loans);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> Post(Loans model)
        {
            loggerManager.LogInfo("Post()");
            if (ModelState.IsValid)
            {
                var obj = await loansService.AddLoan(model);
                return Ok(obj);
            }
            return BadRequest(model);
        }

    }
}
