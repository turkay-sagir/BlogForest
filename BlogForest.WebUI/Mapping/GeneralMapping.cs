using AutoMapper;
using BlogForest.DtoLayer.BlogDtos;
using BlogForest.EntityLayer.Concrete;
using BlogForest.WebUI.Controllers;

namespace BlogForest.WebUI.Mapping
{
	public class GeneralMapping:Profile
	{
        public GeneralMapping()
        {
            CreateMap<Blog,CreateBlogDto>();
            CreateMap<CreateBlogDto,Blog>();
        }
    }
}
