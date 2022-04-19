using System.ComponentModel.DataAnnotations;

namespace E02_contact_form.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage = "ErrorRequired")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "ErrorRequired")]
        [EmailAddress(ErrorMessage = "ErrorEmailAddress")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "ErrorRequired")]
        public string Message { get; set; } = string.Empty;
    }
}