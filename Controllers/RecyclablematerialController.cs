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
    public class RecyclablematerialController : ControllerBase
    {
        private DBContextRecilife _dbContextRecilife;
        public RecyclablematerialController(DBContextRecilife context)
        {
            _dbContextRecilife = context;
        }
        [HttpGet]
        [Route("getRecyclablematerial/")]
        public ActionResult<List<Recyclablematerial>> Get()
        {
            return _dbContextRecilife.Recyclablematerial.ToList();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Recyclablematerial> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Recyclablematerial id must be higher than zero");
            }
            Recyclablematerial ob = _dbContextRecilife.Recyclablematerial.FirstOrDefault(s => s.id == id);
            if (ob == null)
            {
                return NotFound(" Recyclablematerial not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Recyclablematerial recyclablematerial)
        {
            if (recyclablematerial == null)
            {
                return NotFound("recyclablematerial data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextRecilife.Recyclablematerial.AddAsync(recyclablematerial);
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(recyclablematerial);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Recyclablematerial recyclablematerial)
        {
            if (recyclablematerial == null)
            {
                return NotFound("recyclablematerial data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Recyclablematerial ob = _dbContextRecilife.Recyclablematerial.FirstOrDefault(s => s.id == recyclablematerial.id);
            if (ob == null)
            {
                return NotFound("Recyclablematerial does not exist in the database");
            }
            ob.active = recyclablematerial.active;
            ob.description = recyclablematerial.description;
            ob.id = recyclablematerial.id;
            ob.name = recyclablematerial.name;
            _dbContextRecilife.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(_dbContextRecilife);
        }
    }
}
