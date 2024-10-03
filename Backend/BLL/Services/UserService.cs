using AutoMapper;
using BLL.DTOs;
using DAL.EF.TableModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, UserInfo>();
                cfg.CreateMap<UserInfo, UserDTO>();
            });
            return new Mapper(config);
        }
        public static bool Create(UserDTO d)
        {
            
            var con = GetMapper().Map<UserInfo>(d);
            return DataAccessFactory.UserData().Create(con);
        }
        public static bool Update(UserDTO d)
        {
            var con = GetMapper().Map<UserInfo>(d);
            return DataAccessFactory.UserData().Update(con);
        }
        public static bool Delete(int d)
        {
            return DataAccessFactory.UserData().Delete(d);
        }
        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserData().Get(id);
            return GetMapper().Map<UserDTO>(data);
        }
        public static List<UserDTO> GetAll()
        {
            var data = DataAccessFactory.UserData().GetAll();
            return GetMapper().Map<List<UserDTO>>(data);
        }
    }
}
