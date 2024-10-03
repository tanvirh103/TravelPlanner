using DAL.EF.TableModels;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<UserInfo, int, bool> UserData()
        {
            return new UserRepo();
        }
        public static IRepo<TripInfo, int, bool> TripData()
        {
            return new TripRepo();
        }
        public static IRepo<BudgetInfo, int, bool> BudgetData()
        {
            return new BudgetRepo();
        }
        public static IRepo<PackingInfo, int, bool> PackingData()
        {
            return new PackingRepo();
        }
        public static IRepo<TripShareInfo, int, bool> TripShareData()
        {
            return new TripShareRepo();
        }
        public static IAuth AuthData() {
            return new UserRepo();
        }
    }
}
