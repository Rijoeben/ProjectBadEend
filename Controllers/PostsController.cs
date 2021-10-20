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
    public class PostsController : ControllerBase
    {
        private IBadeendDataContext _data;

        public PostsController(IBadeendDataContext data)
        {
            _data = data;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Posts>> Get()
        {
            return Ok(_data.GetPosts());
        }

        [HttpGet("{user_id}")]
        public ActionResult<IEnumerable<Posts>> Get(int user_id)
        {
            return Ok(_data.GetPosts(user_id));
        }

        [HttpGet("post/{post_id}")]
        public ActionResult<Posts> GetPost(int post_id)
        {
            return Ok(_data.GetPost(post_id));
        }






        [HttpPost]
        [Authorize(Policy = "BasicAuthentication", Roles = "Root,Admin,User")]
        public ActionResult<Posts> Post([FromBody] Posts post)
        {
            _data.AddPost(post);
            return Ok("Record added");
        }




        [HttpPut]
        [Authorize(Policy = "BasicAuthentication", Roles = "Root,Admin")]
        public ActionResult<Posts> Put(int id, [FromBody] Posts post)
        {
            _data.UpdatePost(id, post);
            return Ok("Record updated");
        }
    }
}
