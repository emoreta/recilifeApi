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
    public class TemplateemailController : ControllerBase
    {
        private DBContextRecilife _dbContextRecilife;
        public TemplateemailController(DBContextRecilife context)
        {
            _dbContextRecilife = context;
        }
        [HttpGet]
        [Route("getTemplateemail/")]
        public ActionResult<List<Templateemail>> Get()
        {
            return _dbContextRecilife.Templateemail.ToList();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Templateemail> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Templateemail id must be higher than zero");
            }
            Templateemail ob = _dbContextRecilife.Templateemail.FirstOrDefault(s => s.id == id);
            if (ob == null)
            {
                return NotFound(" Templateemail not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Templateemail templateemail)
        {
            if (templateemail == null)
            {
                return NotFound("templateemail data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextRecilife.Templateemail.AddAsync(templateemail);
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(templateemail);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Templateemail templateemail)
        {
            if (templateemail == null)
            {
                return NotFound("templateemail data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Templateemail ob = _dbContextRecilife.Templateemail.FirstOrDefault(s => s.id == templateemail.id);
            if (ob == null)
            {
                return NotFound("Templateemail does not exist in the database");
            }
            ob.active = templateemail.active;
            ob.description = templateemail.description;
            ob.id = templateemail.id;
            ob.name = templateemail.name;
            ob.template = templateemail.template;
            _dbContextRecilife.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(_dbContextRecilife);
        }
    }
}
