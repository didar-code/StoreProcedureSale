using System.ComponentModel.DataAnnotations;

namespace SaleStoredEvidence.Models.ViewModels
{
    public class SalesViewModel
    {
        public int SalesId { get; set; }

        [Required]
        public DateTime SaleDate { get; set; } = DateTime.Today;

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public string ClientName { get; set; } = string.Empty;

        [Required]
        public string MobileNo { get; set; } = string.Empty;

        public string? ClientImage { get; set; }

        [Required]
        public int PaymentMethodId { get; set; }

        public bool IsPaid { get; set; }

        public IFormFile? ProfileFile { get; set; }

        public List<PaymentMethod> PaymentMethods { get; set; } = new();

        public List<PropertyViewModel> Properties { get; set; } = new();
    }

    public class PropertyViewModel
    {
        public int PropertyId { get; set; }

        public string? PropertyType { get; set; }

        public string? Location { get; set; }

        public int SalesId { get; set; }
    }
}
