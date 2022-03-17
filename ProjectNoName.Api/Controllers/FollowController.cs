using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectNoName.Business.Abstract;
using ProjectNoName.Business.Dto;
using ProjectNoName.Core.Results;
using ProjectNoName.Entities;
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
    public class FollowController : ControllerBase
    {
        readonly IRelationShipService _relationShipService;
        readonly IMapper _mapper;
        public FollowController(IRelationShipService relationShipService, IMapper mapper)
        {
            _relationShipService = relationShipService;
            _mapper = mapper;
        }

        [HttpPost("Follow")]
        public async Task<IActionResult> Follow([FromBody] FollowDto followDto)
        {
            return Ok(await _relationShipService.Insert(_mapper.Map<RelationShip>(followDto)));
        }


    }
}
