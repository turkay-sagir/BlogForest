using BlogForest.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogForest.BusinessLayer.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        List<Blog> TGetBlogsWithCategoryAndUser();
        List<Blog> TGetLast2BlogByAppUser(int id);
        List<Blog> TGetBlogsByAppUser(int id);
        void TIncreaseBlogViewCount(int id);
    }
}
