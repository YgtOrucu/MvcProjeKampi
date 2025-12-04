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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        private readonly AboutValidation _validationRulesAbout;


        public AboutManager(IAboutDal aboutDal, AboutValidation validationRulesAbout)
        {
            _aboutDal = aboutDal;
            _validationRulesAbout = validationRulesAbout;
        }

        public void TDelete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About TGetID(int id)
        {
            return _aboutDal.GetID(id);
        }

        public List<About> TGetList()
        {
            return _aboutDal.GetList();
        }

        public void TInsert(About entity)
        {
            About about = new About()
            {
                AboutDetails1 = entity.AboutDetails1,
                AboutDetails2 = entity.AboutDetails2
            };
            var result = _validationRulesAbout.Validate(about);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _aboutDal.Insert(entity);
        }

        public List<About> TListToFilter(Expression<Func<About, bool>> filter)
        {
            return _aboutDal.ListToFilter(filter);
        }

        public void TUpdate(About entity)
        {
            About about = new About()
            {
                AboutDetails1 = entity.AboutDetails1,
                AboutDetails2 = entity.AboutDetails2
            };
            var result = _validationRulesAbout.Validate(about);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _aboutDal.Update(entity);
        }
    }
}
