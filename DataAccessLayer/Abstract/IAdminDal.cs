using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAdminDal : IGenericDal<Admin>
    {
        List<Admin> GetToUserNameAndPassword(string username, string password);
        List<Writer> GetToWriterMailAndPassword(string mail, string password);
    }
}
