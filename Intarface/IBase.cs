using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagment.Intarface
{
    public interface IBase <T> where T:class
    {
        public bool Create(T entity);

        public bool Update(T entity);

        public bool Delete(T entity);

        public bool Save();

        public ICollection<T> FindAll();

        T FindById(int id);

        public bool exists(int id);
         
        
    }
}
