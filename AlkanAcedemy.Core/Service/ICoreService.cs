using AlkanAcademy.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlkanAcademy.Core.Service
{
    public interface ICoreService<T> where T : CoreEntity
    {
        bool Add(T item);
        bool Update(T item);
        bool Delete(int id);
        T GetByID(int id);
        T GetRecord(Expression<Func<T, bool>> expression);
        List<T> GetAll();
    
        
        int Save();

    }
}
