using EntityLayer.Concreate;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService : IGenericService<Heading>
    {
        List<Heading> TGetListByWriter(int id);
        List<Heading> TListTheTRUEHeadingsForUsers();
        List<HeadingCountDto> TGetHeadingNameAndCount();


    }
}
