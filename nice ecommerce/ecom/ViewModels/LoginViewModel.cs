using System.ComponentModel.DataAnnotations;

namespace ecom.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
        public bool RemeberMe { get; set; }
    }
}
