using System;
using System.Collections.Generic;

namespace SaleStoredEvidence.Models;

public partial class Sale
{
    public int SalesId { get; set; }

    public DateTime SaleDate { get; set; }

    public decimal TotalPrice { get; set; }

    public string ClientName { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public string ClientImage { get; set; } = null!;

    public int PaymentMethodId { get; set; }

    public bool IsPaid { get; set; }

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
}
