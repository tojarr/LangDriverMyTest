using System.ComponentModel.DataAnnotations;

namespace LangDriverApi.Common.Models
{
    public class RegisterInfo
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect email address")]
        public string Email { get; set; }
    }
}
