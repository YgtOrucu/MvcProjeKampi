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

        public List<Content> ListContentTheOnesWithTheTrueHeading()
        {
            List<int> ListOnesWithTrueHeading = new List<int>();
            List<Content> GetListContent = new List<Content>();

            var values = c.Headings.Where(x => x.HeadingStatus).Select(y => y.HeadingID).ToList();

            foreach (var item in values)
            {
                ListOnesWithTrueHeading.Add(item);
            }

            for (int i = 0; i < ListOnesWithTrueHeading.Count; i++)
            {
                int id = ListOnesWithTrueHeading[i];
                var getlistContent = c.Contents.Where(x => x.HeadingID == id).ToList();

                GetListContent.AddRange(getlistContent);
            }

            return GetListContent;
        }
    }
}
