using recilife_api.Context;
using recilife_api.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace recilife_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationuserController : ControllerBase
    {
        private DBContextRecilife _dbContextRecilife;
        public LocationuserController(DBContextRecilife context)
        {
            _dbContextRecilife = context;
        }
        [HttpGet]
        [Route("getLocationuser/")]
        public ActionResult<List<Locationuser>> Get()
        {
            return _dbContextRecilife.Locationuser.ToList();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Locationuser> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Locationuser id must be higher than zero");
            }
            Locationuser ob = _dbContextRecilife.Locationuser.FirstOrDefault(s => s.id == id);
            if (ob == null)
            {
                return NotFound(" Locationuser not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Locationuser locationuser)
        {
            if (locationuser == null)
            {
                return NotFound("locationuser data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextRecilife.Locationuser.AddAsync(locationuser);
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(locationuser);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Locationuser locationuser)
        {
            if (locationuser == null)
            {
                return NotFound("locationuser data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Locationuser ob = _dbContextRecilife.Locationuser.FirstOrDefault(s => s.id == locationuser.id);
            if (ob == null)
            {
                return NotFound("Locationuser does not exist in the database");
            }
            ob.active = locationuser.active;
            ob.created = locationuser.created;
            ob.description = locationuser.description;
            ob.id = locationuser.id;
            ob.latitude = locationuser.latitude;
            ob.longitude = locationuser.longitude;
            ob.reference = locationuser.reference;
            _dbContextRecilife.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(_dbContextRecilife);
        }
    }
}
