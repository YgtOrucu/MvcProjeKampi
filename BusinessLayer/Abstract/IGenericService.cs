using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TInsert(T entity);
        void TUpdate(T entity);
        void TDelete(T entity);
        List<T> TGetList();
        T TGetID(int id);
        List<T> TListToFilter(Expression<Func<T, bool>> filter);    //Bu metod şartlı listelemeler için kullanılacak
    }
}
