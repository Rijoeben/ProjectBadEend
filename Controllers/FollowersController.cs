using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMongoDB.Services;
using TestMongoDB.Models;

namespace TestMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowersController : ControllerBase
    {
        private readonly FollowersService _followerService;

        public FollowersController(FollowersService followersService)
        {
            _followerService = followersService;
        }

        [HttpGet]
        public ActionResult<List<Followers>> Get() =>
            _followerService.Get();

        [HttpGet("{id}")]
        public ActionResult<Followers> Get(string id)
        {
            Followers follower = _followerService.Get(id);

            if (follower == null)
            {
                return NotFound();
            }

            return follower;
        }

        [HttpPost]
        public ActionResult<Followers> Create(string userId)
        {
            _followerService.Create(userId);

            return Ok("User created");
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, string follower)
        {
            Followers user = _followerService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            _followerService.Update(id, follower);
            return Ok($"Follower added to user {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Followers follower = _followerService.Get(id);

            if (follower == null)
            {
                return NotFound();
            }

            _followerService.Remove(follower.Id);

            return Ok("User removed");
        }
    }
}