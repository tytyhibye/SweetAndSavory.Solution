using System.ComponentModel.DataAnnotations;

namespace SweetAndSavory.ViewModels
{
  public class RegisterViewModel
  {
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Name")]
    public string Name { get; set; }
    
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "These two passwords definitely don't match.")]
    public string ConfirmPassword { get; set; }
  }
}