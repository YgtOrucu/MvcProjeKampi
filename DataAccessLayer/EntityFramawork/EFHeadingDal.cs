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
    public class EFHeadingDal : GenericRepository<Heading>, IHeadingDal
    {
        MvcKampContext c = new MvcKampContext();
        public List<Heading> GetListByWriter(int id)
        {
            var values = c.Headings.Where(x => x.WriterID == id).ToList();
            return values;
        }
    }
}
