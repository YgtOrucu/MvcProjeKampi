using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class MessageManager : IMessageService
    {
        public readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TDelete(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public Message TGetID(int id)
        {
            return _messageDal.GetID(id);
        }

        public List<Message> TGetList()
        {
            return _messageDal.GetList();
        }

        public List<Message> TListInboxForAdminUser()
        {
            return _messageDal.ListInboxForAdminUser();
        }
        public List<Message> TListSenderForAdminUser()
        {
            return _messageDal.ListSenderForAdminUser();
        }

        public void TInsert(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public List<Message> TListToFilter(Expression<Func<Message, bool>> filter)
        {
            return _messageDal.ListToFilter(filter);
        }

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }

        public int TTotalNumberOfInbox()
        {
            return _messageDal.TotalNumberOfInbox();
        }

        public int TTotalNumberOfSent()
        {
            return _messageDal.TotalNumberOfSent();
        }
    }
}
