using ApiCRUD.Bl.Dto;
using ApiCRUD.Models;
using ApiCRUD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _service;

        public VehicleController( IVehicleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<VehicleDto>>> GetAll()
        {
            return await _service.GetAllVehicles();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDto>> GetVehicleById(int id)
        {
            return await _service.GetVehicle(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateVehicle(VehicleDto vehicleDto)
        {
            if(ModelState.IsValid)
            {
                var created = await _service.AddVehicle(vehicleDto);
                return Created(nameof(CreateVehicle), created);
            }

            return BadRequest();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVehicle( int id, VehicleDto vehicleDto)
        {
            if( ModelState.IsValid )
            {
                var response = await _service.UpdateVehicle(id, vehicleDto);
                
                if( response )
                {
                    return Ok();
                }else
                {
                    return StatusCode(500);
                }
            }
            return BadRequest();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> TurnOnOrOff ( int id)
        {
            var isOn = await _service.TurnOnOrOff(id);
            
            if( isOn ) { 
                return Ok();
            }
            
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehicle( int id )
        {
            var isDeleted = await _service.Delete(id);

            if( isDeleted )
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

    }
}
