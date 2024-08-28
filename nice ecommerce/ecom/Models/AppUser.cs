using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom.Models
{
    public class AppUser : IdentityUser
    {

        public string? Address { get; set; }

        
        [NotMapped]
        public string Role { get; set; }
    }
}
