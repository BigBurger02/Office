using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Office.Data;
using Office.Service;

namespace Office.Controllers;

[ApiController, Route("api/audience")]
public class AudienceController(OfficeDbContext database) : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        var audience = database.Audience
            .Include(x => x.Deanery)
            .Include(x => x.Building)
            .Include(x => x.Cathedra)
            .ToList();
        
        return Ok(audience);
    }
    
    [HttpGet, Route("{id}")]
    public ActionResult Get(int id)
    {
        var audience = database.Audience
            .Find(id);

        if (audience == null)
            return NotFound();

        return Ok(audience);
    }
    
    [HttpPost]
    public ActionResult Post(Audience audience)
    {
        database.Audience.Add(audience);
        database.SaveChanges();

        return Created("", audience);
    }
    
    [HttpPut]
    public ActionResult Put(Audience audience)
    {
        database.Entry(audience).State = EntityState.Modified;
        
        database.SaveChanges();

        return Ok(audience);
    }
    
    [HttpDelete, Route("{id}")]
    public ActionResult Delete(int id)
    {
        var audience = database.Audience
            .Find(id);
        
        if (audience == null)
            return NotFound();

        database.Audience.Remove(audience);
        database.SaveChanges();

        return Ok();
    }
}
