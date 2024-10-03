using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserInfo, AuthDTO>();
            });
            return new Mapper(config);
        }
        public static bool Authenticate(string Email, string Password) { 
            var data=DataAccessFactory.AuthData().Authenticate(Email,Password);
            return data;
        }
    }
}
