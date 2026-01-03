using EntityLayer.Concreate;
using EntityLayer.Models;
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
        List<Heading> ListTheTRUEHeadingsForUsers();

        List<HeadingCountDto> GetHeadingNameAndCount();
    }
}
