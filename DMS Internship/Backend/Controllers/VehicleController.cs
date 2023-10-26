using Dapper;
using DMS_Internship.Backend.Models;
using DMS_Internship.Backend.VehicleServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System.Linq.Expressions;
using static Dapper.SqlMapper;

namespace DMS_Internship.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleService _vehicleService;
     
        public VehicleController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public IActionResult GetAll(int newVehicleID)
        {
            var data = _vehicleService.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _vehicleService.GetById(id);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]//AddById
        public IActionResult Create(VehicleEntity entity)
        {
            var data = _vehicleService.Create(entity);
            if(data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [HttpPut("{id}")]//updateById
        public IActionResult Update(int id, VehicleEntity entity)
        {
            var data = _vehicleService.Update(id, entity);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [HttpDelete("{id}")]//DeleteById
        public IActionResult Delete(int id)
        {
            var data = _vehicleService.Delete(id);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

    }
     }

    
