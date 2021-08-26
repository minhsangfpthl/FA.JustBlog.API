using FA.JustBlog.Data.Infrastructure;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }



        public Category GetCategoryByUrlSlug(string urlSlug)
        {
            return _unitOfWork.CategoryRepository.GetQuery().FirstOrDefault(x => x.UrlSlug == urlSlug);
        }

        public async Task<Category> GetCategoryByUrlSlugAsync(string urlSlug)
        {
            return await _unitOfWork.CategoryRepository.GetQuery().FirstOrDefaultAsync(x => x.UrlSlug == urlSlug);
        }
    }
}
