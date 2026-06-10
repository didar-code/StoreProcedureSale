using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleStoredEvidence.Migrations
{
    /// <inheritdoc />
    public partial class InsertSaleSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE OR ALTER PROCEDURE dbo.InsertSaleSP
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
        DECLARE @SalesId INT;

        INSERT INTO Sales
        (
            SaleDate,
            TotalPrice,
            ClientName,
            MobileNo,
            ClientImage,
            PaymentMethodId,
            IsPaid
        )
        VALUES
        (
            @SaleDate,
            @TotalPrice,
            @ClientName,
            @MobileNo,
            @ClientImage,
            @PaymentMethodId,
            @IsPaid
        );

        SET @SalesId = SCOPE_IDENTITY();
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
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS dbo.InsertSaleSP;");
        }
    }
}
