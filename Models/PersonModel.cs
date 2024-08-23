using System.ComponentModel.DataAnnotations;

namespace pra_test.Models
{
    
        public class PersonModel
        {
            public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(3, ErrorMessage = "Name cannot be longer than 3 characters")]
        public string Name { get; set; }
            [Required, EmailAddress]
            public string Email { get; set; }
            [Required, Phone]
            public string PhoneNo { get; set; }
            public string Address { get; set; }
            [Required]
            public string State { get; set; }
            [Required]
            public string City { get; set; }
        }
    
}
