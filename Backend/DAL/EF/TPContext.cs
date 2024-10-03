using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class TPContext:DbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<TripInfo> TripInfos { get; set; }
        public DbSet<BudgetInfo> BudgetInfos { get; set; }
        public DbSet<PackingInfo> PackingInfos { get; set; }
        public DbSet<TripShareInfo> TripShareInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<TripShareInfo>()
                .HasRequired(ts => ts.UserInfo)
                .WithMany(u => u.TripShareInfos)
                .HasForeignKey(ts => ts.UserId)
                .WillCascadeOnDelete(false); 

            modelBuilder.Entity<TripShareInfo>()
                .HasRequired(ts => ts.TripInfo)
                .WithMany(t => t.TripShareInfos)
                .HasForeignKey(ts => ts.TripId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
