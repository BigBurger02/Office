using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Office.Data;
using Office.Service;

namespace Office.Controllers;

[ApiController, Route("api/deanery")]
public class DeaneryController(OfficeDbContext database) : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        var deanery = database.Deanery
            .ToList();
        
        return Ok(deanery);
    }
    
    [HttpGet, Route("{id}")]
    public ActionResult Get(int id)
    {
        var deanery = database.Deanery
            .Find(id);

        if (deanery == null)
            return NotFound();

        return Ok(deanery);
    }
    
    [HttpPost]
    public ActionResult Post(Deanery deanery)
    {
        database.Deanery.Add(deanery);
        database.SaveChanges();

        return Created("", deanery);
    }
    
    [HttpPut]
    public ActionResult Put(Deanery deanery)
    {
        database.Entry(deanery).State = EntityState.Modified;
        
        database.SaveChanges();

        return Ok(deanery);
    }
    
    [HttpDelete, Route("{id}")]
    public ActionResult Delete(int id)
    {
        var deanery = database.Deanery
            .Find(id);
        
        if (deanery == null)
            return NotFound();

        database.Deanery.Remove(deanery);
        database.SaveChanges();

        return Ok();
    }
}
