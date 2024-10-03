using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PackingDTO
    {
        public int CheckListId { get; set; }
        [Required]
        [StringLength(200,ErrorMessage ="Item name must be within 200 char")]
        public string ItemName { get; set; }
        [Required]
        public bool IsPacked { get; set; }
        public string CreatedAt { get; set; }
        [Required]
        public int TripId { get; set; }
    }
}
