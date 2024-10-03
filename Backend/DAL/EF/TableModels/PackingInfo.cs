using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class PackingInfo
    {
        [Key]
        public int CheckListId { get; set; }
        [Required]
        [StringLength(250)]
        [Column(TypeName = "Varchar")]
        public string ItemName { get; set; }
        [Required]
        [Column(TypeName = "Bit")]
        public bool IsPacked { get; set; }
        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CreatedAt { get; set; }
        public virtual TripInfo TripInfo { get; set; }
        [Required]
        [ForeignKey("TripInfo")]
        public int TripId { get; set; }
    }
}
