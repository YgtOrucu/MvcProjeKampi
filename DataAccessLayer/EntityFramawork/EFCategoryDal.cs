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
    public class EFCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        MvcKampContext context = new MvcKampContext();
        public List<Category> ListCategorytoIDandNameforWriterTable()
        {
            var values = context.Categories.Select(x => new { x.CategoryID, x.CategoryName }).AsEnumerable().Select(y => new Category
            {
                CategoryID = y.CategoryID,
                CategoryName = y.CategoryName
            }).ToList();

            return values;
        }
    }
}
