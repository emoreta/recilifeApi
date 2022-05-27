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
    public class DayController : ControllerBase
    {
        private DBContextRecilife _dbContextRecilife;
        public DayController(DBContextRecilife context)
        {
            _dbContextRecilife = context;
        }
        [HttpGet]
        [Route("getDay/")]
        public ActionResult<List<Day>> Get()
        {
            return _dbContextRecilife.Day.ToList();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Day> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Day id must be higher than zero");
            }
            Day ob = _dbContextRecilife.Day.FirstOrDefault(s => s.id == id);
            if (ob == null)
            {
                return NotFound(" Day not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Day day)
        {
            if (day == null)
            {
                return NotFound("day data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextRecilife.Day.AddAsync(day);
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(day);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Day day)
        {
            if (day == null)
            {
                return NotFound("day data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Day ob = _dbContextRecilife.Day.FirstOrDefault(s => s.id == day.id);
            if (ob == null)
            {
                return NotFound("Day does not exist in the database");
            }
            ob.active = day.active;
            ob.description = day.description;
            ob.id = day.id;
            ob.name = day.name;
            _dbContextRecilife.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(_dbContextRecilife);
        }
    }
}
