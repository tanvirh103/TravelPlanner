using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="UserName must be with in 50 char")]
        public string UserName { get; set; }
        [Required]
        [StringLength(25,MinimumLength =8, ErrorMessage = "Password must be more than 8 char")]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        public string CreatedAt { get; set; }
    }
}
