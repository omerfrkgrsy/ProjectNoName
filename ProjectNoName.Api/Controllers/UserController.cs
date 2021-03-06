using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectNoName.Business.Abstract;
using ProjectNoName.Business.Dto;
using ProjectNoName.Core.Results;
using ProjectNoName.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNoName.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;
        readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetUserList());
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] User user)
        {
            var insertData = await _userService.Insert(user);

            return Ok(new Result(true, "User Registered."));
        }

        [HttpPost("Register")]
        public async Task<IActionResult> UserRegister([FromBody] UserRegisterDto userRegisterDto)
        {
            return Ok(await _userService.Insert(_mapper.Map<User>(userRegisterDto)));
        }

    }
}
