using Microsoft.AspNetCore.Mvc;
using NihalMorshed.VillaApi.Services.Api.Data;
using NihalMorshed.VillaApi.Services.Api.Models.DTOs;

namespace NihalMorshed.VillaApi.Services.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/villaApi")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<VillaDto> getVillas() // <- using ActionResult; preferable due to the documentation use
        {
            return Ok(VillaStore.villaList);
        }

        [HttpGet("id")] // <- When more than one get method is available , we have to put "parameter" so that swagger knows they are different.
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDto))] // <- when using IActionResult; Type is defined here for documentation.
        public IActionResult getById(int id) // <- using IActionResult
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


    }
}
