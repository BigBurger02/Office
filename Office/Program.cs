using Microsoft.EntityFrameworkCore;
using Office.Data;
using Office.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OfficeDbContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", corsPolicyBuilder => corsPolicyBuilder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<OfficeDbContext>();
    
    context.Database.Migrate();
    
    var seeder = new DatabaseSeeder(context);
    seeder.Seed();
}

app.UseCors("CORS");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();