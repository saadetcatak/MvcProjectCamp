using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        List<T> TGetList();
        void TInsert(T t);
        void TUpdate(T t);
        void TDelete(T t);
        T TGetByID(int id);
    }
}
