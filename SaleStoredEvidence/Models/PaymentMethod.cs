
namespace SaleStoredEvidence.Models;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string PaymentType { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
