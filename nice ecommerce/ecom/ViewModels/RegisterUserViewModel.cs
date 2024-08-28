using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ecom.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassowrd { get; set; }
        public string Address { get; set; }
      
    }
}
