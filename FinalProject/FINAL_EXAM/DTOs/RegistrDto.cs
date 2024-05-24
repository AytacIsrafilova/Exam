using System.ComponentModel.DataAnnotations;

namespace FINAL_EXAM.DTOs
{
    public class RegistrDto
    {
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Username { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MaxLength(8)]
        [MinLength(4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MaxLength(8)]
        [MinLength(4)]
        [DataType(DataType.Password),Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
