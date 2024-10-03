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
    public class PackingService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PackingDTO, PackingInfo>();
                cfg.CreateMap<PackingInfo, PackingDTO>();
            });
            return new Mapper(config);
        }
        public static bool Create(PackingDTO p)
        {
            p.CreatedAt= DateTime.Now.ToString("d/M/yyyy");
            var data = GetMapper().Map<PackingInfo>(p);
            return DataAccessFactory.PackingData().Create(data);
        }
        public static bool Update(PackingDTO p)
        {
            var data = GetMapper().Map<PackingInfo>(p);
            return DataAccessFactory.PackingData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.PackingData().Delete(id);
        }
        public static PackingDTO Get(int id)
        {
            var data = DataAccessFactory.PackingData().Get(id);
            return GetMapper().Map<PackingDTO>(data);
        }
        public static List<PackingDTO> GetAll()
        {
            var data = DataAccessFactory.PackingData().GetAll();
            return GetMapper().Map<List<PackingDTO>>(data);
        }
    }
}
