namespace Office.Service;

public class Building
{
    public int Id { get; set; }
    public string? Address { get; set; }
    public string? Type { get; set; }
    public int? NumberOfFloors { get; set; }
    public DateTime? YearBuilt { get; set; }
}