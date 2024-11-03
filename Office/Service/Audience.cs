namespace Office.Service;

public class Audience
{
    public int Id { get; set; }
    public string? AudienceNumber { get; set; }
    public int? FloorNumber { get; set; }
    public string? TeacherName { get; set; }
    public string? TeacherEmail { get; set; }
    public string? TeacherPhone { get; set; }
    public string? Subject { get; set; }
    public string? Equipment { get; set; }
    public int BuildingId { get; set; }
    public int DeaneryId { get; set; }
    public int CathedraId { get; set; }

    public Building? Building { get; set; }
    public Deanery? Deanery { get; set; }
    public Cathedra? Cathedra { get; set; }
}