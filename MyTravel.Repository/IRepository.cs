using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTravel.Repository
{
    public interface IRepository<T> where T:class
    {
        T Add(T entity);
        T Update(T entity);
        bool Delete(int id);
        T SelectById(int id);
        List<T> Select();
    }
}
