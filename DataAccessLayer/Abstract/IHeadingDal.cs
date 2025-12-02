using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IHeadingDal : IGenericDal<Heading>
    {
        List<Heading> GetListByWriter(int id);
    }
}
