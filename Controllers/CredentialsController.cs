using Bad_eend.Data;
using Bad_eend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bad_eend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CredentialsController : ControllerBase
    {
        private IBadeendCredentials _creds;

        public CredentialsController(IBadeendCredentials creds)
        {
            _creds = creds;
        }


        [HttpGet]
        [Authorize(Policy = "BasicAuthentication", Roles = "Root")]
        public ActionResult<IEnumerable<Credentials>> Get()
        {
            return Ok(_creds.GetCredentials());
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "BasicAuthentication", Roles = "Root")]
        public ActionResult<int> Delete(int id)
        {
            _creds.DeleteCredentials(id);
            return Ok("Successfully deleted the credentials with id '"+ id +"'");
        }

        [HttpPost()]
        [Authorize(Policy = "BasicAuthentication", Roles = "Root")]
        public ActionResult<Credentials> Post([FromBody] Credentials creds)
        {
            _creds.AddCredentials(creds);
            return Ok("Successfully added the credentials");
        }
    }
}
