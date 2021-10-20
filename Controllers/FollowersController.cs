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
        public ActionResult<IEnumerable<Followers>> Get()
        {
            return Ok(_followerService.Get());
        }

        [HttpGet("{id:length(24)}", Name = "GetFollower")]
        public ActionResult<Followers> Get(string id)
        {
            var book = _followerService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Followers> Create(string userId)
        {
            _followerService.Create(userId);

            return CreatedAtRoute("GetFollower", new { id = userId.ToString() });
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Followers follower)
        {
            var user = _followerService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _followerService.Update(id, follower);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(int id)
        {
            var follower = _followerService.Get(Convert.ToString(id));

            if (follower == null)
            {
                return NotFound();
            }

            _followerService.Remove(follower.Id);

            return NoContent();
        }
    }
}
