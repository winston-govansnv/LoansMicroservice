using LoansMicroservice.Data.EFCore;
using LoansMicroservice.Logger;
using LoansMicroservice.Models;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager loggerManager;

        public LoansController(IUnitOfWork _unitOfWork, ILoggerManager loggerManager)
        {
            this._unitOfWork = _unitOfWork;
            this.loggerManager = loggerManager;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Loans>> GetByCustomerId(string Id)
        {
            var loans = await _unitOfWork.eFLoansDataRepository.GetLoans(Id);
            return Ok(loans);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> Post(Loans model)
        {
            loggerManager.LogInfo("Post()");
            if (ModelState.IsValid)
            {
                var obj = await _unitOfWork.eFLoansDataRepository.AddLoan(model);
                return Ok(obj);
            }
            return BadRequest(model);
        }

    }
}
