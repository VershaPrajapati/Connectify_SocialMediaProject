using System.ComponentModel.DataAnnotations;

namespace UserMicroservice.DataAccessLayer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        // Add any other properties you need for the User entity

        // Add any navigation properties if necessary

    }
}
