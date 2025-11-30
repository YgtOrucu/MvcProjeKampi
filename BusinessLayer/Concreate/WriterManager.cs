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
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public void TDelete(Writer entity)
        {
            _writerDal.Delete(entity);
        }

        public Writer TGetID(int id)
        {
            return _writerDal.GetID(id);
        }

        public List<Writer> TGetList()
        {
            return _writerDal.GetList();
        }

        public void TInsert(Writer entity)
        {
            _writerDal.Insert(entity);
        }

        public List<Writer> TListToFilter(Expression<Func<Writer, bool>> filter)
        {
            return _writerDal.ListToFilter(filter);
        }

        public void TUpdate(Writer entity)
        {
            _writerDal.Update(entity);
        }
    }
}
