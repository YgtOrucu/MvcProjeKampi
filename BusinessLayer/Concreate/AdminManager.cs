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
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;
        private readonly AdminValidation _validationRulesAdmin;

        public AdminManager(IAdminDal adminDal, AdminValidation validationRulesAdmin)
        {
            _adminDal = adminDal;
            _validationRulesAdmin = validationRulesAdmin;
        }
        public void TDelete(Admin entity)
        {
            _adminDal.Delete(entity);
        }

        public Admin TGetID(int id)
        {
            return _adminDal.GetID(id);
        }

        public List<Admin> TGetList()
        {
            return _adminDal.GetList();
        }


        public void TInsert(Admin entity)
        {
            Admin admin = new Admin()
            {
                UserName = entity.UserName,
                Password = entity.Password
            };
            var result = _validationRulesAdmin.Validate(admin);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _adminDal.Insert(entity);
        }

        public List<Admin> TListToFilter(Expression<Func<Admin, bool>> filter)
        {
            return _adminDal.ListToFilter(filter);
        }

        public void TUpdate(Admin entity)
        {
            Admin admin = new Admin()
            {
                UserName = entity.UserName,
                Password = entity.Password
            };
            var result = _validationRulesAdmin.Validate(admin);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _adminDal.Update(entity);
        }
        public List<Admin> TGetToUserNameAndPassword(string username, string password)
        {
            Admin admin = new Admin()
            {
                UserName = username,
                Password = password
            };
            var result = _validationRulesAdmin.Validate(admin);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            return _adminDal.GetToUserNameAndPassword(username, password);
        }
    }
}
