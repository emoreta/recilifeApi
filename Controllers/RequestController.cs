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
    public class RequestController : ControllerBase
    {
        private DBContextRecilife _dbContextRecilife;
        public RequestController(DBContextRecilife context)
        {
            _dbContextRecilife = context;
        }
        [HttpGet]
        [Route("getRequest/")]
        public ActionResult<List<Request>> Get()
        {
            return _dbContextRecilife.Request.ToList();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Request> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Request id must be higher than zero");
            }
            Request ob = _dbContextRecilife.Request.FirstOrDefault(s => s.id == id);
            if (ob == null)
            {
                return NotFound(" Request not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Request request)
        {
            if (request == null)
            {
                return NotFound("request data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextRecilife.Request.AddAsync(request);
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(request);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Request request)
        {
            if (request == null)
            {
                return NotFound("request data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Request ob = _dbContextRecilife.Request.FirstOrDefault(s => s.id == request.id);
            if (ob == null)
            {
                return NotFound("Request does not exist in the database");
            }
            ob.amount = request.amount;
            ob.calification = request.calification;
            ob.commentary = request.commentary;
            ob.created = request.created;
            ob.distance = request.distance;
            ob.id = request.id;
            ob.idstate = request.idstate;
            ob.idstaterecycler = request.idstaterecycler;
            ob.iduserrecycler = request.iduserrecycler;
            ob.iduserrequest = request.iduserrequest;
            ob.updated = request.updated;
            _dbContextRecilife.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(_dbContextRecilife);
        }
    }
}
