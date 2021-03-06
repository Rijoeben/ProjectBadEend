using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bad_eend
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IBadeendDataContext _data;

        public UsersController(IBadeendDataContext data)
        {
            _data = data;
        }

        [HttpGet]
        [Authorize(Policy = "BasicAuthentication", Roles = "Root,User")]
        public ActionResult<IEnumerable<Users>> Get()
        {
            return Ok(_data.GetUsers());
        }
        [HttpGet("{user_id}")]
        [Authorize(Policy = "BasicAuthentication", Roles = "Root")]
        public ActionResult<IEnumerable<Users>> GetUser(int user_id)
        {
            return Ok(_data.GetUser(user_id));
        }

        [HttpPost]
        [Authorize(Policy = "BasicAuthentication", Roles = "Root,Admin,User")]
        public ActionResult<Users> Post([FromBody] Users user)
        {
            _data.AddUser(user);
            return Ok("Gg well played");
        }

        [HttpPut("{user_id}/UpdateLastPosted")]
        [Authorize(Policy = "BasicAuthentication", Roles = "Root,Admin")]
        public ActionResult<Users> Update(int user_id)
        {
            _data.UpdateLastPosted(user_id, DateTime.Now);
            return Ok("Record updated");
        }
             
        [HttpDelete]
        [Authorize(Policy = "BasicAuthentication", Roles = "Root,Admin")]
        public ActionResult<Users> DeleteUser(int user_id)
        {
            _data.DeleteUser(user_id);
            return Ok("User deleted");

        }
    }
}
