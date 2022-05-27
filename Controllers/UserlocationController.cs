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
    public class UserlocationController : ControllerBase
    {
        private DBContextRecilife _dbContextRecilife;
        public UserlocationController(DBContextRecilife context)
        {
            _dbContextRecilife = context;
        }
        [HttpGet]
        [Route("getUserlocation/")]
        public ActionResult<List<Userlocation>> Get()
        {
            return _dbContextRecilife.Userlocation.ToList();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Userlocation> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Userlocation id must be higher than zero");
            }
            Userlocation ob = _dbContextRecilife.Userlocation.FirstOrDefault(s => s.id == id);
            if (ob == null)
            {
                return NotFound(" Userlocation not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Userlocation userlocation)
        {
            if (userlocation == null)
            {
                return NotFound("userlocation data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextRecilife.Userlocation.AddAsync(userlocation);
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(userlocation);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Userlocation userlocation)
        {
            if (userlocation == null)
            {
                return NotFound("userlocation data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Userlocation ob = _dbContextRecilife.Userlocation.FirstOrDefault(s => s.id == userlocation.id);
            if (ob == null)
            {
                return NotFound("Userlocation does not exist in the database");
            }
            ob.active = userlocation.active;
            ob.id = userlocation.id;
            ob.idlocation = userlocation.idlocation;
            ob.iduser = userlocation.iduser;
            _dbContextRecilife.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(_dbContextRecilife);
        }
    }
}
