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
    public class TripService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TripDTO, TripInfo>();
                cfg.CreateMap<TripInfo, TripDTO>();
            });
            return new Mapper(config);
        }
        public static bool Create(TripDTO t)
        {
            t.CreateAt= DateTime.Now.ToString("d/M/yyyy");
            var data = GetMapper().Map<TripInfo>(t);
            return DataAccessFactory.TripData().Create(data);
        }
        public static bool Update(TripDTO t)
        {
            var data = GetMapper().Map<TripInfo>(t);
            return DataAccessFactory.TripData().Update(data);
        }
        public static bool Delete(int t)
        {
            return DataAccessFactory.TripData().Delete(t);
        }
        public static TripDTO Get(int t)
        {
            var data = DataAccessFactory.TripData().Get(t);
            return GetMapper().Map<TripDTO>(data);
        }
        public static List<TripDTO> GetAll()
        {
            var data = DataAccessFactory.TripData().GetAll();
            return GetMapper().Map<List<TripDTO>>(data);
        }
    }
}
