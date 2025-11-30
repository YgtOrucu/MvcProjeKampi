using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramawork
{
    public class EFCategoryDal : GenericRepository<Category>, ICategoryDal
    {
    }
}
