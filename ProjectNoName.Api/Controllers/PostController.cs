using AutoMapper;
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
        readonly IMapper _mapper;
        public PostController(IPostService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetList();
            return Ok(new DataResult<List<PostListDto>>(data, true, "Post Data Listed."));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] PostCreateDto post)
        {
            var insertData = await _service.Insert(_mapper.Map<Post>(post));

            return Ok(new Result(true,"Post Added."));
        }
    }
}
