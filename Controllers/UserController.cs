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
    public class UserController : ControllerBase
    {
        private DBContextRecilife _dbContextRecilife;
        public UserController(DBContextRecilife context)
        {
            _dbContextRecilife = context;
        }
        [HttpGet]
        [Route("getUser/")]
        public ActionResult<List<User>> Get()
        {
            return _dbContextRecilife.User.ToList();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<User> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("User id must be higher than zero");
            }
            User ob = _dbContextRecilife.User.FirstOrDefault(s => s.id == id);
            if (ob == null)
            {
                return NotFound(" User not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            if (user == null)
            {
                return NotFound("user data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextRecilife.User.AddAsync(user);
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(user);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] User user)
        {
            if (user == null)
            {
                return NotFound("user data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User ob = _dbContextRecilife.User.FirstOrDefault(s => s.id == user.id);
            if (ob == null)
            {
                return NotFound("User does not exist in the database");
            }
            ob.active = user.active;
            ob.bussinesname = user.bussinesname;
            ob.calification = user.calification;
            ob.created = user.created;
            ob.email = user.email;
            ob.field1 = user.field1;
            ob.field2 = user.field2;
            ob.id = user.id;
            ob.idsessiontype = user.idsessiontype;
            ob.idusertype = user.idusertype;
            ob.identificationruc = user.identificationruc;
            ob.image = user.image;
            ob.lastname = user.lastname;
            ob.mobilenumber = user.mobilenumber;
            ob.name = user.name;
            ob.password = user.password;
            ob.telephone = user.telephone;
            ob.token = user.token;
            ob.updated = user.updated;
            ob.userid = user.userid;
            _dbContextRecilife.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextRecilife.SaveChangesAsync();
            return Ok(_dbContextRecilife);
        }
    }
}
