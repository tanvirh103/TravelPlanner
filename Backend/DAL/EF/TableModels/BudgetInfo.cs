using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class BudgetInfo
    {
        [Key]
        public int BudgetId { get; set; }
        [Required]
        [StringLength(100)]
        [Column(TypeName = "Varchar")]
        public string BudgetItem { get; set; }
        [Required]
        [Column(TypeName = "Float")]
        public float EstimatedCost { get; set; }
        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CreateAt { get; set; }
        public virtual TripInfo TripInfo { get; set; }
        [Required]
        [ForeignKey("TripInfo")]
        public int TripId { get; set; }
    }
}
