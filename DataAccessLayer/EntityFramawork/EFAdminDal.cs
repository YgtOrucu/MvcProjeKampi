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
    public class EFAdminDal : GenericRepository<Admin>, IAdminDal
    {
        MvcKampContext context = new MvcKampContext();
       
        public List<Admin> GetToUserNameAndPassword(string username, string password)
        {
            var values = context.Admins.Where(x => x.UserName == username && x.Password == password).ToList();
            return values;
        }
    }
}
