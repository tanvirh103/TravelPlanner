using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<UserInfo, int, bool>,IAuth
    {
        public bool Create(UserInfo obj)
        {
            var Email = obj.Email;
            var check=!db.UserInfos.Any(u => u.Email == Email);
            if (check == true) {
                return false;
            }
            db.UserInfos.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = db.UserInfos.Find(id);
            db.UserInfos.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public UserInfo Get(int id)
        {
            return db.UserInfos.Find(id); ;
        }

        public List<UserInfo> GetAll()
        {
            return db.UserInfos.ToList();
        }

        public bool Update(UserInfo User)
        {
            var exobj = db.UserInfos.Find(User.UserId);
            exobj.UserName = User.UserName;
            exobj.Password = User.Password;
            exobj.Email = User.Email;
            return db.SaveChanges() > 0;

        }

        public bool Authenticate(string Email, string Password) {
            var login = (from u in db.UserInfos
                         where u.Email.Equals(Email) &&
                         u.Password.Equals(Password)
                         select u).SingleOrDefault();
            return login != null;
        }
    }
}
