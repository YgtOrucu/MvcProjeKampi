using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramawork
{
    public class EFContentDal : GenericRepository<Content>, IContentDal
    {
        MvcKampContext c = new MvcKampContext();
        public List<Content> GetListContentByHeading(int id)
        {
            var values = c.Contents.Where(x => x.HeadingID == id).ToList();
            return values;
        }
    }
}
