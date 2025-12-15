using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService : IGenericService<Admin>
    {
        List<Admin> TGetToUserNameAndPassword(string username, string password);
        List<Writer> TGetToWriterMailAndPassword(string mail, string password);

    }
}
