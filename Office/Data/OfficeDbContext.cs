using Office.Service;
using Microsoft.EntityFrameworkCore;

namespace Office.Data;

public class OfficeDbContext(DbContextOptions<OfficeDbContext> options) : DbContext(options)
{
    public DbSet<Building> Building { get; set; }
    public DbSet<Deanery> Deanery { get; set; }
    public DbSet<Cathedra> Cathedra { get; set; }
    public DbSet<Audience> Audience { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlite("Data Source=Db.db;");

        base.OnConfiguring(builder);
    }
}