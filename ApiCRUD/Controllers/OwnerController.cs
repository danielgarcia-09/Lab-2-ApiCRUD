using ApiCRUD.Bl.Dto;
using ApiCRUD.Models;
using ApiCRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _service;
        public OwnerController(IOwnerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<OwnerDto>> GetList ()
        {
            return await _service.GetAllOwners();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOwner (int id)
        {
            var owner = await _service.GetOwner(id);

            if( owner == null )
            {
                return NotFound();
            } 

            return Ok(owner);
        }

        [HttpPost]
        public async Task<ActionResult> AddOwner ( OwnerDto ownerDto )
        {
            if (ModelState.IsValid)
            {
                var created = await _service.AddOwner(ownerDto);
                if( created == null )
                {
                    return BadRequest();
                }
                return Created(nameof(AddOwner), created);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOwner( int id, OwnerDto ownerDto )
        {
            if(ModelState.IsValid)
            {
                var isUpdated = await _service.UpdateOwner(id, ownerDto);

                if( isUpdated )
                {
                    return Ok();
                }
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOwner(int id)
        {
            var isDeleted = await _service.DeleteOwner(id);

            if( isDeleted ) 
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
