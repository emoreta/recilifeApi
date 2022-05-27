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
    public class UsertypeController : ControllerBase
    {
        private DBContextRecilife _dbContextRecilife;
        public UsertypeController(DBContextRecilife context)
        {
            _dbContextRecilife = context;
        }
        [HttpGet]
        [Route("getUsertype/")]
        public ActionResult<List<Usertype>> Get()
        {
            return _dbContextRecilife.Usertype.ToList();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Usertype> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Usertype id must be higher than zero");
            }
            Usertype ob = _dbContextRecilife.Usertype.FirstOrDefault(s => s.id == id);
            if (ob == null)
            {
                return NotFound(" Usertype not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Usertype usertype)
        {
            if (usertype == null)
            {
                return NotFound("usertype data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextRecilife.Usertype.AddAsync(usertype);
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(usertype);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Usertype usertype)
        {
            if (usertype == null)
            {
                return NotFound("usertype data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Usertype ob = _dbContextRecilife.Usertype.FirstOrDefault(s => s.id == usertype.id);
            if (ob == null)
            {
                return NotFound("Usertype does not exist in the database");
            }
            ob.description = usertype.description;
            ob.id = usertype.id;
            ob.name = usertype.name;
            _dbContextRecilife.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(_dbContextRecilife);
        }
    }
}
