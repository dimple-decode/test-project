using System.ComponentModel.DataAnnotations;

namespace CRUD_Resonsive_Web_API.Models
{
    public class SignInModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
