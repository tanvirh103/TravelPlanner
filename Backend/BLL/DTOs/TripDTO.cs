using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TripDTO
    {
        public int TripId { get; set; }
        [Required]
        [StringLength(100,ErrorMessage ="Destination must be in 100 char")]
        public string Destination { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        [Required]
        [StringLength(200,ErrorMessage = "Itinerary name must be with in 200 char")]
        public string Itinerary { get; set; }
        public string CreateAt { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
