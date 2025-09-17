using System.ComponentModel.DataAnnotations;
namespace InevntoryManagementSystem.Models.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string? FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]

        [Required]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        
    }
}
