using System;
using System.Collections.Generic;
using System.IO;
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
    public class PetsController : ControllerBase
    {
        private IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }
        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetPets();
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                return Ok(_petService.CreatePet(pet.Name, pet.Type, pet.Birthdate, pet.SoldDate, pet.Color, pet.PreviousOwner, pet.Price));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id != pet.ID)
            {
                return BadRequest($"The Id you entered and that of the pet does NOT match, you can't change the id");
            }
            try
            {
                return Ok(_petService.UpdatePet(id, pet.Name, pet.Type, pet.Birthdate, pet.SoldDate, pet.Color, pet.PreviousOwner,
                    pet.Price));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            try
            {
                return Ok(_petService.DeletePet(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
