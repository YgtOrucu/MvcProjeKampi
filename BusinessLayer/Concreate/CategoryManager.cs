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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly CategoryValitadions _validationRulesCategory;

        public CategoryManager(ICategoryDal categoryDal, CategoryValitadions validationRulesCategory)
        {
            _categoryDal = categoryDal;
            _validationRulesCategory = validationRulesCategory;
            
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category TGetID(int id)
        {
            return _categoryDal.GetID(id);
        }

        public List<Category> TGetList()
        {
            return _categoryDal.GetList();
        }

        public void TInsert(Category entity)
        {
            Category category = new Category()
            {
                CategoryName = entity.CategoryName
            };
            var result = _validationRulesCategory.Validate(category);
            if(!result.IsValid) throw new ValidationException(result.Errors);
            _categoryDal.Insert(entity);
        }

        public List<Category> TListCategorytoIDandNameforWriterTable()
        {
            return _categoryDal.ListCategorytoIDandNameforWriterTable();
        }

        public List<Category> TListToFilter(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.ListToFilter(filter);
        }

        public void TUpdate(Category entity)
        {
            Category category = new Category()
            {
                CategoryName = entity.CategoryName
            };
            var result = _validationRulesCategory.Validate(category);
            if (!result.IsValid) throw new ValidationException(result.Errors);
            _categoryDal.Update(entity);
        }
    }
}
