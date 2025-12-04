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
    public class ContentManager : IContentService
    {
        private readonly IContentDal _contentDal;
        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }
        public void TDelete(Content entity)
        {
            _contentDal.Delete(entity);
        }

        public Content TGetID(int id)
        {
            return _contentDal.GetID(id);
        }

        public List<Content> TGetList()
        {
            return _contentDal.GetList();
        }

        public List<Content> TGetListContentByHeading(int id)
        {
            return _contentDal.GetListContentByHeading(id);
        }

        public void TInsert(Content entity)
        {
            _contentDal.Insert(entity);
        }

        public List<Content> TListToFilter(Expression<Func<Content, bool>> filter)
        {
            return _contentDal.ListToFilter(filter);
        }

        public void TUpdate(Content entity)
        {
            _contentDal.Update(entity);
        }
    }
}
