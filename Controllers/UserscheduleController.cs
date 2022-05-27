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
    public class UserscheduleController : ControllerBase
    {
        private DBContextRecilife _dbContextRecilife;
        public UserscheduleController(DBContextRecilife context)
        {
            _dbContextRecilife = context;
        }
        [HttpGet]
        [Route("getUserschedule/")]
        public ActionResult<List<Userschedule>> Get()
        {
            return _dbContextRecilife.Userschedule.ToList();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Userschedule> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Userschedule id must be higher than zero");
            }
            Userschedule ob = _dbContextRecilife.Userschedule.FirstOrDefault(s => s.id == id);
            if (ob == null)
            {
                return NotFound(" Userschedule not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Userschedule userschedule)
        {
            if (userschedule == null)
            {
                return NotFound("userschedule data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextRecilife.Userschedule.AddAsync(userschedule);
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(userschedule);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Userschedule userschedule)
        {
            if (userschedule == null)
            {
                return NotFound("userschedule data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Userschedule ob = _dbContextRecilife.Userschedule.FirstOrDefault(s => s.id == userschedule.id);
            if (ob == null)
            {
                return NotFound("Userschedule does not exist in the database");
            }
            ob.id = userschedule.id;
            ob.idschedule = userschedule.idschedule;
            ob.iduser = userschedule.iduser;
            _dbContextRecilife.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(_dbContextRecilife);
        }
    }
}
