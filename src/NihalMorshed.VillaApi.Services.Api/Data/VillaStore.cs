using NihalMorshed.VillaApi.Services.Api.Models.DTOs;

namespace NihalMorshed.VillaApi.Services.Api.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>
        {
            new VillaDto
            {
                Id = 1,
                Name = "Test 1",
                Sqft = 1220,
                MaxOccupancy = 10,
            },
            new VillaDto
            {
                Id = 2,
                Name = "Test 2",
                Sqft = 1105,
                MaxOccupancy = 7,
            }

        };
    }
}
