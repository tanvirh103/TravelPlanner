using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TripRepo : Repo, IRepo<TripInfo, int, bool>
    {
        public bool Create(TripInfo obj)
        {
            db.TripInfos.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool Delete(int id)
        {
            var data=db.TripInfos.Find(id);
            db.TripInfos.Remove(data);
            return db.SaveChanges()>0;
        }

        public TripInfo Get(int id)
        {
            return db.TripInfos.Find(id);
        }

        public List<TripInfo> GetAll()
        {
           return db.TripInfos.ToList();
        }

        public bool Update(TripInfo Obj)
        {
            var exobj = db.TripInfos.Find(Obj.TripId);
            exobj.Destination = Obj.Destination;
            exobj.StartDate = Obj.StartDate;
            exobj.EndDate = Obj.EndDate;
            exobj.Itinerary = Obj.Itinerary;
            return db.SaveChanges()>0;
        }
    }
}
