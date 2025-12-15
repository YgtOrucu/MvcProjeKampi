using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        List<Message> TListInboxForAdminUser();
        List<Message> TListSenderForAdminUser();
        int TTotalNumberOfInbox();
        int TTotalNumberOfSent();

        List<Message> TListInboxForWriterUser(string mail);
        List<Message> TListSenderForWriterUser(string mail);
        int TTotalNumberOfWriterInbox(string mail);
        int TTotalNumberOfWriterSent(string mail);
    }
}
