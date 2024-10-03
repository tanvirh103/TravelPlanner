using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class UserInfo
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CreatedAt { get; set; }
        public virtual ICollection<TripInfo> TripInfo { get; set; }
        public virtual ICollection<TripShareInfo> TripShareInfos { get; set; }
        public UserInfo()
        {
            TripShareInfos = new List<TripShareInfo>();
            TripInfo = new List<TripInfo>();
        }

    }
}
