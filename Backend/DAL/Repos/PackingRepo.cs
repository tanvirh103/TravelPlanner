using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PackingRepo : Repo, IRepo<PackingInfo, int, bool>
    {
        public bool Create(PackingInfo obj)
        {
            db.PackingInfos.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = db.PackingInfos.Find(id);
            db.PackingInfos.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public PackingInfo Get(int id)
        {
            return db.PackingInfos.Find(id);
        }

        public List<PackingInfo> GetAll()
        {
            return db.PackingInfos.ToList();
        }

        public bool Update(PackingInfo obj)
        {
            var exobj = db.PackingInfos.Find(obj.CheckListId);
            exobj.ItemName = obj.ItemName;
            exobj.IsPacked = obj.IsPacked;
            return db.SaveChanges() > 0;
        }
    }
}
