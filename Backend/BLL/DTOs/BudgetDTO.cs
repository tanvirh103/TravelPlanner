using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BudgetDTO
    {
        public int BudgetId { get; set; }
        [Required]
        [StringLength(100,ErrorMessage ="Budget Item Name must be in 100 char")]
        public string BudgetItem { get; set; }
        [Required]
        public float EstimatedCost { get; set; }
        public string CreateAt { get; set; }
        [Required]
        public int TripId { get; set; }
    }
}
