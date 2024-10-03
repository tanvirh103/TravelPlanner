using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class TripInfo
    {
        [Key]
        public int TripId { get; set; }
        [Required]
        [StringLength(100)]
        [Column(TypeName = "Varchar")]
        public string Destination { get; set; }
        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string StartDate { get; set; }
        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string EndDate { get; set; }
        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Itinerary { get; set; }
        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CreateAt { get; set; }

        public virtual UserInfo UserInfo { get; set; }
        [Required]
        [ForeignKey("UserInfo")]
        public int UserId { get; set; }
        public virtual ICollection<BudgetInfo> Budgets { get; set; }
        public virtual ICollection<PackingInfo> Packings { get; set; }
        public virtual ICollection<TripShareInfo> TripShareInfos { get; set; }
        public TripInfo()
        {
            TripShareInfos = new List<TripShareInfo>();
            Packings = new List<PackingInfo>();
            Budgets=new List<BudgetInfo>();
        }
    }
}
