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
    public class BudgetService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BudgetDTO, BudgetInfo>();
                cfg.CreateMap<BudgetInfo, BudgetDTO>();
            });
            return new Mapper(config);
        }
        public static bool Create(BudgetDTO b)
        {
            b.CreateAt= DateTime.Now.ToString("d/M/yyyy");
            var data = GetMapper().Map<BudgetInfo>(b);
            return DataAccessFactory.BudgetData().Create(data);
        }
        public static bool Update(BudgetDTO b)
        {
            var data = GetMapper().Map<BudgetInfo>(b);
            return DataAccessFactory.BudgetData().Update(data);
        }
        public static bool Delete(int b)
        {
            return DataAccessFactory.BudgetData().Delete(b);
        }
        public static BudgetDTO Get(int id)
        {
            var data = DataAccessFactory.BudgetData().Get(id);
            return GetMapper().Map<BudgetDTO>(data);
        }
        public static List<BudgetDTO> GetAll()
        {
            var data = DataAccessFactory.BudgetData().GetAll();
            return GetMapper().Map<List<BudgetDTO>>(data);
        }
    }
}
