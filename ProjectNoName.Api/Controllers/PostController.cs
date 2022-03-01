using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectNoName.Business.Abstract;
using ProjectNoName.Business.Dto;
using ProjectNoName.Core.Results;
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
            var data = await _service.GetList();
            return Ok(new DataResult<List<PostListDto>>(data, true, "Post Data Listed."));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Post post)
        {
            var insertData = await _service.Insert(post);

            return Ok(new Result(true,"Post Added."));
        }
    }
}
