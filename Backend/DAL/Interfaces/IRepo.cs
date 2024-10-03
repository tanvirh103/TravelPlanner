using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS, ID, RET>
    {
        CLASS Get(ID id);
        List<CLASS> GetAll();
        RET Delete(ID id);
        RET Update(CLASS Obj);
        RET Create(CLASS obj);
    }
}
