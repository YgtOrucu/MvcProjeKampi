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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public void TDelete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public Contact TGetID(int id)
        {
            return _contactDal.GetID(id);
        }

        public List<Contact> TGetList()
        {
            return _contactDal.GetList();
        }

        public void TInsert(Contact entity)
        {
            _contactDal.Insert(entity);
        }

        public List<Contact> TListToFilter(Expression<Func<Contact, bool>> filter)
        {
            return _contactDal.ListToFilter(filter);
        }

        public int TTotalNumberOfUserMessage()
        {
            return _contactDal.TotalNumberOfUserMessage();
        }

        public void TUpdate(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
