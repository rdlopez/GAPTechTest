using System.Collections.Generic;
using System.Linq;

namespace GoIn.DataAccess.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        int Delete(List<int> ids);

        bool Delete(int id);

        bool Exists(object primaryKey);

        IQueryable<T> GetAll();

        int Insert(List<T> entities);

        int Insert(T entity);

        T Single(object primaryKey);

        T SingleOrDefault(object primaryKey);

        void Update(List<T> Entities);

        void Update(T Entity);
    }
}