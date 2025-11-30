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
    public class HeadingManager : IHeadingService
    {
        private readonly IHeadingDal _headingDal;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }
        public void TDelete(Heading entity)
        {
            _headingDal.Delete(entity);
        }

        public Heading TGetID(int id)
        {
            return _headingDal.GetID(id);
        }

        public List<Heading> TGetList()
        {
            return _headingDal.GetList();
        }

        public void TInsert(Heading entity)
        {
            _headingDal.Insert(entity);
        }

        public List<Heading> TListToFilter(Expression<Func<Heading, bool>> filter)
        {
            return _headingDal.ListToFilter(filter);
        }

        public void TUpdate(Heading entity)
        {
            _headingDal.Update(entity);
        }
    }
}
