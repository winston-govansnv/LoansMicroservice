using LoansMicroservice.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoansMicroservice.Models
{
    public class Loans : IEntity
    {
        public Guid Id { get; set; }
        [Required]
        public int LoanNumber { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime StartDt { get; set; }
        [Required]
        public string LoanType { get; set; }
        [Required]
        public int TotalLoan { get; set; }
        [Required]
        public int AmountPaid { get; set; }
        [Required]
        public int OutstandingAmount { get; set; }
        [Required]
        public DateTime CreateDt { get; set; }

    }
}
