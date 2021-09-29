using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoansMicroservice.Migrations
{
    public partial class AddLoanstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LoanNumber = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    StartDt = table.Column<int>(type: "integer", nullable: false),
                    LoanType = table.Column<int>(type: "integer", nullable: false),
                    TotalLoan = table.Column<int>(type: "integer", nullable: false),
                    AmountPaid = table.Column<int>(type: "integer", nullable: false),
                    OutstandingAmount = table.Column<int>(type: "integer", nullable: false),
                    CreateDt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
