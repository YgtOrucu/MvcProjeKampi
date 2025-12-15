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
    public class EFMessageDal : GenericRepository<Message>, IMessageDal
    {
        MvcKampContext c = new MvcKampContext();
        public List<Message> ListInboxForAdminUser()
        {
            var values = c.Messages.Where(x => x.ReceiverMail == "admin@gmail.com").ToList();
            return values;
        }

        public List<Message> ListSenderForAdminUser()
        {
            var values = c.Messages.Where(x => x.SenderMail == "admin@gmail.com").ToList();
            return values;
        }

        public int TotalNumberOfInbox()
        {
            int Inboxcount = c.Messages.Where(x => x.ReceiverMail == "admin@gmail.com").Count();
            return Inboxcount;
        }

        public int TotalNumberOfSent()
        {
            int sentCount = c.Messages.Where(x => x.SenderMail == "admin@gmail.com").Count();
            return sentCount;
        }
        public List<Message> ListInboxForWriterUser(string mail)
        {
            var values = c.Messages.Where(x => x.ReceiverMail == mail).ToList();
            return values;
        }

        public List<Message> ListSenderForWriterUser(string mail)
        {
            var values = c.Messages.Where(x => x.SenderMail == mail).ToList();
            return values;
        }

        public int TotalNumberOfWriterInbox(string mail)
        {
            int Inboxcount = c.Messages.Where(x => x.ReceiverMail == mail).Count();
            return Inboxcount;
        }

        public int TotalNumberOfWriterSent(string mail)
        {
            int sentCount = c.Messages.Where(x => x.SenderMail == mail).Count();
            return sentCount;
        }
    }
}
