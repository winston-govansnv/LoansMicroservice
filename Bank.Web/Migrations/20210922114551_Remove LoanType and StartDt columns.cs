using Microsoft.EntityFrameworkCore.Migrations;

namespace LoansMicroservice.Migrations
{
    public partial class RemoveLoanTypeandStartDtcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanType",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "StartDt",
                table: "Loans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoanType",
                table: "Loans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartDt",
                table: "Loans",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
