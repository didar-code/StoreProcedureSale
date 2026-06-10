using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleStoredEvidence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSaleSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE OR ALTER PROCEDURE dbo.UpdateSaleSP
    @SalesId INT,
    @SaleDate DATETIME,
    @TotalPrice DECIMAL(18,2),
    @ClientName NVARCHAR(100),
    @MobileNo NVARCHAR(20),
    @ClientImage NVARCHAR(MAX),
    @PaymentMethodId INT,
    @IsPaid BIT
    
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        UPDATE Sales
        SET SaleDate = @SaleDate,
            TotalPrice = @TotalPrice,
            ClientName = @ClientName,
            MobileNo = @MobileNo,
            ClientImage = @ClientImage,
            PaymentMethodId = @PaymentMethodId,
            IsPaid = @IsPaid
        WHERE SalesId = @SalesId;

       

        
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
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS dbo.UpdateSaleSP;");
        }
    }
}
