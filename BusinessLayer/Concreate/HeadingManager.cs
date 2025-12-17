using BusinessLayer.Abstract;
using BusinessLayer.Valitadions;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class HeadingManager : IHeadingService
    {
        private readonly IHeadingDal _headingDal;
        private readonly HeadingValidation _validationRulesHeading;
        public HeadingManager(IHeadingDal headingDal, HeadingValidation validationRulesHeading)
        {
            _headingDal = headingDal;
            _validationRulesHeading = validationRulesHeading;
        }
        public void TDelete(Heading entity)
        {
            _headingDal.Delete(entity);
        }

        public Heading TGetID(int id)
        {
            return _headingDal.GetID(id);
        }

        public List<Heading> TGetList()
        {
            return _headingDal.GetList();
        }

        public List<Heading> TGetListByWriter(int id)
        {
            return _headingDal.GetListByWriter(id);
        }

        public void TInsert(Heading entity)
        {
            Heading heading = new Heading()
            {
                HeadingName = entity.HeadingName,
                HeadingDate = entity.HeadingDate
            };
            var result = _validationRulesHeading.Validate(heading);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _headingDal.Insert(entity);
        }

        public List<Heading> TListTheTRUEHeadingsForUsers()
        {
            return _headingDal.ListTheTRUEHeadingsForUsers();
        }

        public List<Heading> TListToFilter(Expression<Func<Heading, bool>> filter)
        {
            return _headingDal.ListToFilter(filter);
        }

        public void TUpdate(Heading entity)
        {
            _headingDal.Update(entity);
        }
    }
}
