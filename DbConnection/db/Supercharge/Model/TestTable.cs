namespace DbConnection.db.Supercharge.Model;

public partial class TestTable
{
    public int TestTableId { get; set; }

    public string? FirstData { get; set; }

    public string? SecondData { get; set; }

    public string? ThirdData { get; set; }

    public bool IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOnUtc { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }
}
