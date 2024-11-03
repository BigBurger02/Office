using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Office.Data;

namespace Office.Service;

public class DatabaseSeeder
{
    private readonly OfficeDbContext _context;

    public DatabaseSeeder(OfficeDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        if (!_context.Audience.Any())
        {
            var buildings = GenerateBuildings();
            var deaneries = GenerateDeaneries();
            var cathedras = GenerateCathedras(deaneries);
            var audiences = GenerateAudiences(buildings, deaneries, cathedras);

            _context.Building.AddRange(buildings);
            _context.Deanery.AddRange(deaneries);
            _context.Cathedra.AddRange(cathedras);
            _context.Audience.AddRange(audiences);
            _context.SaveChanges();
        }
    }

    private List<Building> GenerateBuildings()
    {
        var addresses = new[] { "123 Main St", "456 Oak St", "789 Pine St", "101 Maple Ave", "202 Birch Blvd" };
        var types = new[] { "Academic", "Administrative", "Library" };
        var random = new Random();

        return Enumerable.Range(1, 3).Select(i => new Building
        {
            Address = addresses[random.Next(addresses.Length)],
            Type = types[random.Next(types.Length)],
            NumberOfFloors = random.Next(1, 10),
            YearBuilt = DateTime.Now.AddYears(-random.Next(10, 50))
        }).ToList();
    }

    private List<Deanery> GenerateDeaneries()
    {
        var names = new[] { "Engineering", "Humanities", "Sciences", "Law", "Medicine" };
        var deans = new[] { "Dr. Smith", "Dr. Jones", "Dr. Taylor", "Dr. Brown", "Dr. Lee" };
        var random = new Random();
        List<Deanery> deaneries = new();

        for (int i = 0; i <= 4; i++)
        {
            var rend = names[random.Next(names.Length)];
            var deanery = new Deanery
            {
                DeaneryName = rend + " Deanery",
                Description = "Responsible for overseeing departments within the field of " + rend,
                Dean = deans[random.Next(deans.Length)],
                DeanEmail = $"dean{random.Next(1, 100)}@university.edu",
                DeanPhone = $"123-555-{random.Next(1000, 9999)}"
            };
            deaneries.Add(deanery);
        }

        return deaneries;
    }

    private List<Cathedra> GenerateCathedras(List<Deanery> deaneries)
    {
        var names = new[] { "Physics", "Mathematics", "History", "Literature", "Chemistry" };
        var heads = new[] { "Prof. Adams", "Prof. Clark", "Prof. Hall", "Prof. Allen", "Prof. Miller" };
        var random = new Random();
        var cathedras = new List<Cathedra>();

        foreach (var deanery in deaneries)
        {
            for (int i = 0; i < 2; i++) // 2 cathedras per deanery
            {
                var rand = names[random.Next(names.Length)];
                cathedras.Add(new Cathedra
                {
                    CathedraName = rand + " Cathedra",
                    Description = "Department specializing in " + rand,
                    Head = heads[random.Next(heads.Length)],
                    HeadEmail = $"head{random.Next(1, 100)}@university.edu",
                    HeadPhone = $"123-555-{random.Next(1000, 9999)}",
                    Deanery = deanery
                });
            }
        }

        return cathedras;
    }

    private List<Audience> GenerateAudiences(List<Building> buildings, List<Deanery> deaneries, List<Cathedra> cathedras)
    {
        var subjects = new[] { "Math", "Physics", "Literature", "Chemistry", "History" };
        var equipments = new[] { "Projector", "Computer", "Whiteboard", "Lab Equipment" };
        var teachers = new[] { "Dr. White", "Dr. Green", "Prof. Black", "Prof. Gray", "Ms. Blue" };
        var random = new Random();
        var audiences = new List<Audience>();

        // foreach (var building in buildings)
        // {
        //     foreach (var deanery in deaneries)
        //     {
        //         foreach (var cathedra in cathedras.Where(c => c.DeaneryId == deanery.Id))
        //         {
        //             audiences.Add(new Audience
        //             {
        //                 AudienceNumber = $"A-{random.Next(100, 999)}",
        //                 FloorNumber = random.Next(1, building.NumberOfFloors ?? 3),
        //                 TeacherName = teachers[random.Next(teachers.Length)],
        //                 TeacherEmail = $"teacher{random.Next(1, 100)}@university.edu",
        //                 TeacherPhone = $"123-555-{random.Next(1000, 9999)}",
        //                 Subject = subjects[random.Next(subjects.Length)],
        //                 Equipment = equipments[random.Next(equipments.Length)],
        //                 Building = building,
        //                 Deanery = deanery,
        //                 Cathedra = cathedra
        //             });
        //         }
        //     }
        // }
        foreach (var cathedra in cathedras)
        {
            for (int i = 0; i < 3; i++)
            {
                var building = buildings[random.Next(buildings.Count)];
                var deanery = deaneries[random.Next(deaneries.Count)];

                audiences.Add(new Audience
                {
                    AudienceNumber = $"A-{random.Next(100, 999)}",
                    FloorNumber = random.Next(1, building.NumberOfFloors ?? 3),
                    TeacherName = teachers[random.Next(teachers.Length)],
                    TeacherEmail = $"teacher{random.Next(1, 100)}@university.edu",
                    TeacherPhone = $"123-555-{random.Next(1000, 9999)}",
                    Subject = subjects[random.Next(subjects.Length)],
                    Equipment = equipments[random.Next(equipments.Length)],
                    Building = building,
                    Deanery = deanery,
                    Cathedra = cathedra
                });
            }
        }

        return audiences;
    }
}