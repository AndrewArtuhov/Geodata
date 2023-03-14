using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class AddressModel
    {
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        public string NumberHouse { get; set; }

    }
}
