using BusinessLayer.Abstract;
using BusinessLayer.Valitadions;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace BusinessLayer.Concreate
{
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;
        private readonly WriterValitadion _WritervalidationRules;
        public WriterManager(IWriterDal writerDal,WriterValitadion WritervalidationRules)
        {
            _writerDal = writerDal;
            _WritervalidationRules = WritervalidationRules;
        }
        public void TDelete(Writer entity)
        {
            _writerDal.Delete(entity);
        }

        public Writer TGetID(int id)
        {
            return _writerDal.GetID(id);
        }

        public List<Writer> TGetList()
        {
            return _writerDal.GetList();
        }

        public void TInsert(Writer entity)
        {
            Writer writer = new Writer()
            {
                WriterName = entity.WriterName,
                WriterSurname = entity.WriterSurname,
                WriterAbout = entity.WriterAbout,
                WriterMail = entity.WriterMail,
                WriterPassword = entity.WriterPassword
            };
            var result = _WritervalidationRules.Validate(writer);
            if(!result.IsValid) throw new ValidationException(result.Errors);
            _writerDal.Insert(entity);
        }

        public List<Writer> TListToFilter(Expression<Func<Writer, bool>> filter)
        {
            return _writerDal.ListToFilter(filter);
        }

        public List<Writer> TListWritertoIDandNameforWriterTable()
        {
            return _writerDal.ListWritertoIDandNameforWriterTable();
        }

        public void TUpdate(Writer entity)
        {
            _writerDal.Update(entity);
        }
    }
}
