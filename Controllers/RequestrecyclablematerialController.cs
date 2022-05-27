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
    public class RequestrecyclablematerialController : ControllerBase
    {
        private DBContextRecilife _dbContextRecilife;
        public RequestrecyclablematerialController(DBContextRecilife context)
        {
            _dbContextRecilife = context;
        }
        [HttpGet]
        [Route("getRequestrecyclablematerial/")]
        public ActionResult<List<Requestrecyclablematerial>> Get()
        {
            return _dbContextRecilife.Requestrecyclablematerial.ToList();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Requestrecyclablematerial> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Requestrecyclablematerial id must be higher than zero");
            }
            Requestrecyclablematerial ob = _dbContextRecilife.Requestrecyclablematerial.FirstOrDefault(s => s.id == id);
            if (ob == null)
            {
                return NotFound(" Requestrecyclablematerial not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Requestrecyclablematerial requestrecyclablematerial)
        {
            if (requestrecyclablematerial == null)
            {
                return NotFound("requestrecyclablematerial data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextRecilife.Requestrecyclablematerial.AddAsync(requestrecyclablematerial);
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(requestrecyclablematerial);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Requestrecyclablematerial requestrecyclablematerial)
        {
            if (requestrecyclablematerial == null)
            {
                return NotFound("requestrecyclablematerial data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Requestrecyclablematerial ob = _dbContextRecilife.Requestrecyclablematerial.FirstOrDefault(s => s.id == requestrecyclablematerial.id);
            if (ob == null)
            {
                return NotFound("Requestrecyclablematerial does not exist in the database");
            }
            ob.id = requestrecyclablematerial.id;
            ob.idrecyclablematerial = requestrecyclablematerial.idrecyclablematerial;
            ob.idrequest = requestrecyclablematerial.idrequest;
            _dbContextRecilife.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(_dbContextRecilife);
        }
    }
}
