using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleStoredEvidence.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSaleSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE OR ALTER PROCEDURE dbo.DeleteSaleSP
    @SalesId INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DELETE FROM Properties WHERE SalesId = @SalesId;
        DELETE FROM Sales WHERE SalesId = @SalesId;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS dbo.DeleteSaleSP;");
        }
    }
}
