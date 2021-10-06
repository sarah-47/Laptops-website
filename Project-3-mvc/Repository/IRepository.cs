using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3_mvc.Repository
{
    interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        int Add(T item);
        bool Delete(int id);
        T Get(int id);
        bool Update(int id, T item);
    }
}
