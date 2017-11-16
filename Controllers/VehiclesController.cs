using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dashboard.Controllers.Resources;
using dashboard.Core.Models;
using dashboard.Core;
using Microsoft.AspNetCore.Authorization;
using System.Collections.ObjectModel;
using dashboard.Hubs;
using dashboard_app.Controllers;
using Microsoft.AspNetCore.SignalR;

namespace dashboard.Controllers
{
    //Apply to all routes
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository repository;
        private readonly IHubContext<DashboardHub> _dashboarHubContext;
        private readonly IUnitOfWork unitOfWork;
        public VehiclesController(IHubContext<DashboardHub> dashboarHubContext, IMapper mapper, IVehicleRepository repository, IUnitOfWork unitOfWork)
        {
            _dashboarHubContext = dashboarHubContext;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            await _dashboarHubContext.Clients.All.InvokeAsync("TestSend", "Message From Vehicle Controller");

            return Ok();
        }

        [HttpGet]
        public async Task<QueryResultResource<VehicleResource>> GetVehicles(VehicleQueryResource filterResource)
        {
            await _dashboarHubContext.Clients.All.InvokeAsync("TestSend", "Message From Vehicle Controller");


            var filter = mapper.Map<VehicleQueryResource, VehicleQuery>(filterResource);
            
            var queryResult = await repository.GetVehicles(filter);            

            return mapper.Map<QueryResult<Vehicle>, QueryResultResource<VehicleResource>>(queryResult);
        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            //Repository call
            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);

        }

        // [HttpPost("/api/vehicles")]
        [HttpPost]
        // [Authorize]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // var model = await context.Models.FindAsync(vehicleResource.ModelId);
            // if (model == null)
            // {
            //     ModelState.AddModelError("ModelId", "Invalid ModelId");
            //     return BadRequest(ModelState);
            // }

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            repository.Add(vehicle);
            await unitOfWork.CompleteAsync();

            //Repository call
            vehicle = await repository.GetVehicle(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }


        [HttpPut("{id}")]
        // [Authorize]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Repository call
            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            vehicle = await repository.GetVehicle(vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        // [Authorize(Roles.RequireAdminRole)]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id, includeRelated: false);

            if (vehicle == null)
            {
                return NotFound();
            }

            repository.Remove(vehicle);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}