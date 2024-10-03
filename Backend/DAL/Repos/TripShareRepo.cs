using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TripShareRepo : Repo, IRepo<TripShareInfo, int, bool>
    
    {
         public bool Create(TripShareInfo obj)
        {
            db.TripShareInfos.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var obj = db.TripShareInfos.Find(id);
            db.TripShareInfos.Remove(obj);
            return db.SaveChanges() > 0;
        }

        public TripShareInfo Get(int id)
        {
            return db.TripShareInfos.Find(id);
        }

        public List<TripShareInfo> GetAll()
        {
            return db.TripShareInfos.ToList();
        }

        public bool Update(TripShareInfo obj)
        {
            var exobj = db.TripShareInfos.Find(obj.ShareId);
            return db.SaveChanges() > 0;
        }
    }
}
