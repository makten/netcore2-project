using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dashboard.Controllers.Resources;
using dashboard.Core;
using dashboard.Core.Models;
using Microsoft.AspNetCore.Mvc;


namespace dashboard.Controllers
{
    [Route("/api/goals")]
    public class GoalsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGoalRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GoalsController(IMapper mapper, IGoalRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IEnumerable<GoalResource>> Get()
        {
            var goals = await _repository.GetGoals();

            return _mapper.Map<IEnumerable<Goal>, IEnumerable<GoalResource>>(goals);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    
}
