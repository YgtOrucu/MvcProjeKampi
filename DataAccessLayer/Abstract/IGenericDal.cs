using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetList();
        T GetID(int id);
        List<T> ListToFilter(Expression<Func<T, bool>> filter);    //Bu metod şartlı listelemeler için kullanılacak

    }
}
