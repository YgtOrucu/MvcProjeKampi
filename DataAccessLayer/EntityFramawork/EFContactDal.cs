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
    public class EFContactDal : GenericRepository<Contact>, IContactDal
    {
        MvcKampContext context = new MvcKampContext();
        public int TotalNumberOfUserMessage()
        {
            var count = context.Contacts.Count();
            return count;
        }
    }
}
