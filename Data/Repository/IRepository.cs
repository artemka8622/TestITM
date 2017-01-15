using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepository<T>
    {
        List<T> GetAllItems();
        List<T> GetItemById(Guid id);
        void Update(T model);
        void Delete(Guid Id);
    }
}
