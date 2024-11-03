using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Office.Data;
using Office.Service;

namespace Office.Controllers;

[ApiController, Route("api/cathedra")]
public class CathedraController(OfficeDbContext database) : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        var cathedra = database.Cathedra
            .Include(x => x.Deanery)
            .ToList();
        
        return Ok(cathedra);
    }
    
    [HttpGet, Route("{id}")]
    public ActionResult Get(int id)
    {
        var cathedra = database.Cathedra
            .Find(id);

        if (cathedra == null)
            return NotFound();

        return Ok(cathedra);
    }
    
    [HttpPost]
    public ActionResult Post(Cathedra cathedra)
    {
        database.Cathedra.Add(cathedra);
        database.SaveChanges();

        return Created("", cathedra);
    }
    
    [HttpPut]
    public ActionResult Put(Cathedra cathedra)
    {
        database.Entry(cathedra).State = EntityState.Modified;
        
        database.SaveChanges();

        return Ok(cathedra);
    }
    
    [HttpDelete, Route("{id}")]
    public ActionResult Delete(int id)
    {
        var cathedra = database.Cathedra
            .Find(id);
        
        if (cathedra == null)
            return NotFound();

        database.Cathedra.Remove(cathedra);
        database.SaveChanges();

        return Ok();
    }
}
