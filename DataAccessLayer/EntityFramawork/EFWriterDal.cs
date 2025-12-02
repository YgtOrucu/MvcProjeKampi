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
    public class EFWriterDal : GenericRepository<Writer>, IWriterDal
    {
        MvcKampContext context = new MvcKampContext();
        public List<Writer> ListWritertoIDandNameforWriterTable()
        {
            var values = context.Writers.Select(x => new { x.WriterID, x.WriterName, x.WriterSurname }).AsEnumerable().Select(y => new Writer
            {
                WriterID = y.WriterID,
                WriterName = y.WriterName,
                WriterSurname = y.WriterSurname
            }).ToList();

            return values;
        }
    }
}
