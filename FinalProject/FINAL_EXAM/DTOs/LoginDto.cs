using System.ComponentModel.DataAnnotations;

namespace FINAL_EXAM.DTOs
{
    public class LoginDto
    {
        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string UsernameOrEmail { get; set; }
        [Required]
        [MaxLength(8)]
        [MinLength(3)]
        public string Password { get; set; }    
        public bool IsRemember { get; set; }
    }
}
