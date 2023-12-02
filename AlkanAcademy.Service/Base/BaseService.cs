using AlkanAcademy.Core.Entity;
using AlkanAcademy.Core.Service;
using AlkanAcademy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlkanAcademy.Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private readonly AlkanAcademyContext _db;

        public BaseService(AlkanAcademyContext db)
        {
            _db = db;
        }

        public bool Add(T item)
        {
            try
            {
                _db.Set<T>().Add(item);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _db.Set<T>().Remove(GetByID(id));
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<T> GetAll() => _db.Set<T>().ToList();

       


        public T GetByID(int id) => _db.Set<T>().Find(id);


        public T GetRecord(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().FirstOrDefault(expression);


        }

        public int Save()
        {
            return _db.SaveChanges();
        }

        public bool Update(T item)
        {
            try
            {
                _db.Set<T>().Update(item);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
