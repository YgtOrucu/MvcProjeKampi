using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IContactDal : IGenericDal<Contact>
    {
        int TotalNumberOfUserMessage();
        List<Contact> GetListToStatus();
    }
}
