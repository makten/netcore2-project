using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dashboard.Controllers.Resources;
using dashboard.Core;
using dashboard.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dashboard_app.Controllers
{
    [Produces("application/json")]
    [Route("/api/environments")]
    public class TeamEnvironmentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITeamEnvironmentRepository _repository;
        private readonly IUnitOfWork _unit;

        public TeamEnvironmentsController(IMapper mapper, ITeamEnvironmentRepository repository, IUnitOfWork unit)
        {
            _mapper = mapper;
            _repository = repository;
            _unit = unit;
        }

        [HttpGet("team/{teamId}")]
        public async Task<IEnumerable<TeamEnvironmentResource>> GetTeamEnvironments(int teamId)
        {
            var teamEnvironEvironments = await _repository.GetTeamEvironments(teamId);

            return _mapper.Map<IEnumerable<TeamEnvironment>, IEnumerable<TeamEnvironmentResource>>(
                teamEnvironEvironments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamEnvironment(int id)
        {
            var teamEnvironment = await _repository.GetTeamEvironmentByIdWithRelations(id);
            if (teamEnvironment == null)
                return NotFound();

            var teamEnvironmentResource = _mapper.Map<TeamEnvironment, TeamEnvironmentResource>(teamEnvironment);

            return Ok(teamEnvironmentResource);
        }

//        [HttpPost]
//        public async Task<IActionResult> Post([FromBody] SaveTeamEnvironmentResource teamEnvironment)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);
//
//            var environment
//            return new TeamEnvironment();
//            
//        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}