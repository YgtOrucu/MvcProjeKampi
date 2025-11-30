using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;


        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TDelete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About TGetID(int id)
        {
            return _aboutDal.GetID(id);
        }

        public List<About> TGetList()
        {
            return _aboutDal.GetList();
        }

        public void TInsert(About entity)
        {
            _aboutDal.Insert(entity);
        }

        public List<About> TListToFilter(Expression<Func<About, bool>> filter)
        {
            return _aboutDal.ListToFilter(filter);
        }

        public void TUpdate(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
