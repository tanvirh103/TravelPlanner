using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TripShareDTO
    {
        public int ShareId { get; set; }
        [Required]
        public int UserId { get; set; }
        public string CreatedAt { get; set; }
        [Required]
        public int TripId { get; set; }
    }
}
