using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPCompetitiveProgramation.Models
{
    public class User
    {
        public int ID { get; set; }
        [Display(Name = "User name")]
        [StringLength(60, MinimumLength = 4)]
        [Required]
        public string UserName { get; set; }
        [StringLength(60, MinimumLength = 8)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "First name")]
        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(60, MinimumLength = 1)]
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}
