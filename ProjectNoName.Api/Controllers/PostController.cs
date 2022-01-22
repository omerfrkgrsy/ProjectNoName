using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectNoName.Business.Abstract;
using ProjectNoName.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNoName.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        readonly IPostService _service;
        public PostController(IPostService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll(null,x=>x.Comments,x=>x.User));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Post post)
        {
            return Ok(await _service.Insert(post));
        }
    }
}
