using System.ComponentModel.DataAnnotations;

namespace E02_contact_form.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "EmailAddress")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Required")]
        public string Message { get; set; } = string.Empty;
    }
}