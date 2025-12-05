using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessageDal : IGenericDal<Message>
    {
        List<Message> ListInboxForAdminUser();
        List<Message> ListSenderForAdminUser();
        int TotalNumberOfInbox();
        int TotalNumberOfSent();
    }
}
