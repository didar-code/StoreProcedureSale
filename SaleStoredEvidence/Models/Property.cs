namespace SaleStoredEvidence.Models;

public partial class Property
{
    public int PropertyId { get; set; }

    public string PropertyType { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int SalesId { get; set; }

    public virtual Sale Sales { get; set; } = null!;
}
