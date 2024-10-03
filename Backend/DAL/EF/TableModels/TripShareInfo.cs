using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class TripShareInfo
    {
        [Key]
        public int ShareId { get; set; }

        public virtual UserInfo UserInfo { get; set; }
        [Required]
        [ForeignKey("UserInfo")]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CreatedAt { get; set; }

        public virtual TripInfo TripInfo { get; set; }

        [Required]
        [ForeignKey("TripInfo")]
        public int TripId { get; set; }

        public virtual ICollection<UserInfo> UserInfos { get; set; }
        public virtual ICollection<TripInfo> TripInfos { get; set; }
        public TripShareInfo()
        {
            UserInfos = new List<UserInfo>();
            TripInfos = new List<TripInfo>();
        }

    }
}
