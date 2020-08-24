using System;
using System.ComponentModel.DataAnnotations;

namespace Project2_RESTService.Models
{
    public class Users
    {
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
