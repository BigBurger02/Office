using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Office.Data;
using Office.Service;

namespace Office.Controllers;

[ApiController, Route("api/building")]
public class BuildingController(OfficeDbContext database) : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        var building = database.Building
            .ToList();
        
        return Ok(building);
    }
    
    [HttpGet, Route("{id}")]
    public ActionResult Get(int id)
    {
        var building = database.Building
            .Find(id);

        if (building == null)
            return NotFound();

        return Ok(building);
    }
    
    [HttpPost]
    public ActionResult Post(Building building)
    {
        database.Building.Add(building);
        database.SaveChanges();

        return Created("", building);
    }
    
    [HttpPut]
    public ActionResult Put(Building building)
    {
        database.Entry(building).State = EntityState.Modified;
        
        database.SaveChanges();

        return Ok(building);
    }
    
    [HttpDelete, Route("{id}")]
    public ActionResult Delete(int id)
    {
        var building = database.Building
            .Find(id);
        
        if (building == null)
            return NotFound();

        database.Building.Remove(building);
        database.SaveChanges();

        return Ok();
    }
}
