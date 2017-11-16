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

namespace dashboard.Controllers
{

    //Apply to all routes
    // [Route("/api/dashboard")]
    public class DashboardController : Controller
    {


        //TO DO
        //Get total number of cars - per month, year
        // Get vehicle make counts
        // Get sold, viewed
        // Get added this month ect.

        private readonly IVehicleRepository repository;
        private readonly IMapper mapper;
        public DashboardController(IMapper mapper, IVehicleRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<QueryResultResource<VehicleResource>> GetAllVehicles()
        {

            var queryResult = await repository.GetVehicleCount();

            return mapper.Map<QueryResult<Vehicle>, QueryResultResource<VehicleResource>>(queryResult);
        }


    }
}