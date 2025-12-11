using Microsoft.AspNetCore.Mvc;
using NihalMorshed.VillaApi.Services.Api.Data;
using NihalMorshed.VillaApi.Services.Api.Models.DTOs;

namespace NihalMorshed.VillaApi.Services.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/villaApi")]
    [ApiController] // Identifies as an api controller and enables functionalities like ModelState Validation
    public class VillaApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<VillaDto> GetVillas() // <- using ActionResult; preferable due to the documentation use
        {
            return Ok(VillaStore.villaList);
        }

        [HttpGet("id", Name = "GetVillaById")] // <- When more than one get method is available , we have to put "parameter" so that swagger knows they are different. "Name" needed for the CreatedAtRoute functionality 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDto))] // <- when using IActionResult; Type is defined here for documentation.
        public IActionResult GetById(int id) // <- using IActionResult
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var vil = VillaStore.villaList.FirstOrDefault(y => y.Id == id);
            if (vil == null)
            {
                return NotFound();
            }

            return Ok(vil);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villa)
        {
            //if (!ModelState.IsValid) //   <-  Use this to validate when [ApiController] is not present at the start to validate automatically
            //{
            //    return BadRequest();
            //}

            // Adding Custom Validation Error to ModelState for checking if the name exists already on db
            if (VillaStore.villaList.FirstOrDefault(u => u.Name.ToLower() == villa.Name.ToLower()) != null)
            {
                ModelState.AddModelError("NihalError", "This Naam etimoddhei exist!"); // <- adds ModelError
                return BadRequest(ModelState);
            }
            if (villa == null)
            {
                return BadRequest();
            }
            if (villa.Id != 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            villa.Id = VillaStore.villaList.OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villa);
            return CreatedAtRoute("GetVillaById", new { villa.Id }, villa); // <- CreatedAtRoute returns a 201 Created response with a Location header of the URI of the newly created resource (used for POST methods)
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<VillaDto> DeleteVillaById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            VillaStore.villaList.Remove(villa);
            return Ok(villa); // or May return NoContent()


        }



        [HttpPut("{id:int}", Name = "UpdateVillaById")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<VillaDto> UpdateVilla(int id, [FromBody] VillaDto villa)
        {
            if (id != villa.Id || villa == null)
            {
                return BadRequest();
            }

            var v = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            v.Name = villa.Name;
            v.Sqft = villa.Sqft;
            v.MaxOccupancy = villa.MaxOccupancy;

            return NoContent();

        }
    }
}
