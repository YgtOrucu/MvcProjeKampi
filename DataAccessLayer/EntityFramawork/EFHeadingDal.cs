using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using EntityLayer.Concreate;
using EntityLayer.Models;
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

        public List<HeadingCountDto> GetHeadingNameAndCount()
        {
            var values = (from h in c.Headings
                          where h.HeadingStatus == true
                          join ct in c.Contents on h.HeadingID equals ct.HeadingID into gj
                          from sub in gj.DefaultIfEmpty()
                          group sub by new { h.HeadingID, h.HeadingName } into g
                          select new HeadingCountDto
                          {
                              HeadingID = g.Key.HeadingID,
                              HeadingName = g.Key.HeadingName,
                              Count = g.Count(x => x != null)
                          }).ToList();

            return values;
        }

        public List<Heading> GetListByWriter(int id)
        {
            var values = c.Headings.Where(x => x.WriterID == id).ToList();
            return values;
        }

        public List<Heading> ListTheTRUEHeadingsForUsers()
        {
            var values = c.Headings.Where(x => x.HeadingStatus == true).ToList();
            return values;
        }
    }
}
