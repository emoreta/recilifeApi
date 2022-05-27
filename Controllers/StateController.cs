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
    public class StateController : ControllerBase
    {
        private DBContextRecilife _dbContextRecilife;
        public StateController(DBContextRecilife context)
        {
            _dbContextRecilife = context;
        }
        [HttpGet]
        [Route("getState/")]
        public ActionResult<List<State>> Get()
        {
            return _dbContextRecilife.State.ToList();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<State> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("State id must be higher than zero");
            }
            State ob = _dbContextRecilife.State.FirstOrDefault(s => s.id == id);
            if (ob == null)
            {
                return NotFound(" State not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] State state)
        {
            if (state == null)
            {
                return NotFound("state data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextRecilife.State.AddAsync(state);
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(state);
        }
        [HttpPut]
        [Route("update/{idState}")]
        public async Task<ActionResult> Update(int idState,[FromBody] State state)
        
        {
            if (state == null)
            {
                return NotFound("state data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            State ob = _dbContextRecilife.State.FirstOrDefault(s => s.id == idState);
            if (ob == null)
            {
                return NotFound("State does not exist in the database");
            }
            ob.active = state.active;
            //ob.description = state.description;
            _dbContextRecilife.Entry(ob).Property(x => x.description).IsModified = true;
            ob.field = state.field;
            //ob.id = state.id;
            //ob.name = state.name;
            _dbContextRecilife.Entry(ob).Property(x => x.name).IsModified = true;
            _dbContextRecilife.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(_dbContextRecilife);
        }
        [HttpDelete("delete{id:int}")]
        public async Task<ActionResult<State>> DeleteState(int id)
        {
            /*try
            {
                var employeeToDelete = await _dbContextRecilife.g(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await employeeRepository.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }*/
            return Ok();
        }
    }
}
