using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BudgetRepo:Repo, IRepo<BudgetInfo, int, bool>
    {
        public bool Create(BudgetInfo obj)
        {
            db.BudgetInfos.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = db.BudgetInfos.Find(id);
            db.BudgetInfos.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public BudgetInfo Get(int id)
        {
            return db.BudgetInfos.Find(id);
        }

        public List<BudgetInfo> GetAll()
        {
            return db.BudgetInfos.ToList();
        }

        public bool Update(BudgetInfo B)
        {
            var exobj = db.BudgetInfos.Find(B.BudgetId);
            exobj.BudgetItem = B.BudgetItem;
            exobj.EstimatedCost = B.EstimatedCost;
            return db.SaveChanges() > 0;
        }
    }
}
