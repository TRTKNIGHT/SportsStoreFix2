using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SportsStore.Models.DTO
{
    public class ProductDTO
    {
        [Required]
        public long? ProductID { get; set; }

        [Required]
        public IFormFile? ImageFile { get; set; }
    }
}
