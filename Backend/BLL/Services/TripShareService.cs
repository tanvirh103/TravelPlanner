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
    public class TripShareService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TripShareDTO, TripShareInfo>();
                cfg.CreateMap<TripShareInfo, TripShareDTO>();
            });
            return new Mapper(config);
        }

        public static bool Create(TripShareDTO t)
        {
            t.CreatedAt= DateTime.Now.ToString("d/M/yyyy");
            var data = GetMapper().Map<TripShareInfo>(t);
            return DataAccessFactory.TripShareData().Create(data);
        }
        public static bool Update(TripShareDTO t)
        {
            var data = GetMapper().Map<TripShareInfo>(t);
            return DataAccessFactory.TripShareData().Update(data);
        }
        public static bool Delete(int t)
        {
            return DataAccessFactory.TripShareData().Delete(t);
        }
        public static TripShareDTO Get(int t)
        {
            var data = DataAccessFactory.TripShareData().Get(t);
            return GetMapper().Map<TripShareDTO>(data);
        }
        public static List<TripShareDTO> GetAll()
        {
            var data = DataAccessFactory.TripShareData().GetAll();
            return GetMapper().Map<List<TripShareDTO>>(data);
        }
    }
}
