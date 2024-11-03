namespace Office.Service;

public class Cathedra
{
    public int Id { get; set; }
    public string? CathedraName { get; set; }
    public string? Description { get; set; }
    public string? Head { get; set; }
    public string? HeadEmail { get; set; }
    public string? HeadPhone { get; set; }
    public int DeaneryId { get; set; }
    public Deanery? Deanery { get; set; }
}