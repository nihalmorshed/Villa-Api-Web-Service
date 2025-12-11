using System.ComponentModel.DataAnnotations;

namespace NihalMorshed.VillaApi.Services.Api.Models.DTOs
{
    public class VillaDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public int Sqft { get; set; }
        public int MaxOccupancy { get; set; }
    }
}
