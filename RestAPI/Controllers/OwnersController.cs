using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop2019.Core.ApplicationService;
using PetShop2019.Core.Entities;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        // GET api/owners
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.ReadOwners();
        }

        // POST api/owners
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            try
            {
                return Ok(_ownerService.CreateOwner(owner));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // PUT api/owners/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            try
            {
                return Ok(_ownerService.UpdateOwner(id, owner));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // DELETE api/owners/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            try
            {
               return  Ok(_ownerService.DeleteOwner(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}