using System.ComponentModel.DataAnnotations;

namespace GlobalWeb.Models;

public class Contact {
  [Required(ErrorMessage = "Email is required.")]
  [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
  [Display(Name = "Your Email.")]
  public string? Email { get; set; }
}
