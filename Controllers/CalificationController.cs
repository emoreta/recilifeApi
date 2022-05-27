using recilife_api.Context;
using recilife_api.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace arnuv_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalificationController : ControllerBase
    {
        private DBContextRecilife _dbContextRecilife;
        public CalificationController(DBContextRecilife context)
        {
            _dbContextRecilife = context;
        }
        [HttpGet]
        [Route("getCalification/")]
        public ActionResult<List<Calification>> Get()
        {
            return _dbContextRecilife.Calification.ToList();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Calification> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Calification id must be higher than zero");
            }
            Calification ob = _dbContextRecilife.Calification.FirstOrDefault(s => s.id == id);
            if (ob == null)
            {
                return NotFound(" Calification not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Calification calification)
        {
            if (calification == null)
            {
                return NotFound("calification data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextRecilife.Calification.AddAsync(calification);
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(calification);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Calification calification)
        {
            if (calification == null)
            {
                return NotFound("calification data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Calification ob = _dbContextRecilife.Calification.FirstOrDefault(s => s.id == calification.id);
            if (ob == null)
            {
                return NotFound("Calification does not exist in the database");
            }
            //ob.active = calification.active;
            //ob.created = calification.created;
            ob.id = calification.id;
            _dbContextRecilife.Entry(ob).Property(x => x.name).IsModified = true;
            //ob.name = calification.name;
            //ob.punctuation = calification.punctuation;
            _dbContextRecilife.Entry(ob).Property(x => x.punctuation).IsModified = true;

            _dbContextRecilife.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(_dbContextRecilife);
        }
    }
}
