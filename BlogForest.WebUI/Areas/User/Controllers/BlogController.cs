using AutoMapper;
using BlogForest.BusinessLayer.Abstract;
using BlogForest.DtoLayer.BlogDtos;
using BlogForest.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/Blog")]
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;


		public BlogController(UserManager<AppUser> userManager, IBlogService blogService, IMapper mapper)
		{
			_userManager = userManager;
			_blogService = blogService;
			_mapper = mapper;
		}

		public async Task<IActionResult> MyBlogList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _blogService.TGetBlogsByAppUser(user.Id);
            return View(values);
        }

        [HttpGet]
        [Route("CreateBlog")]
        public IActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateBlog")]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
			var user = await _userManager.FindByNameAsync(User.Identity.Name);

            createBlogDto.AppUserId = user.Id;
            createBlogDto.CreatedTime = DateTime.Now;
            createBlogDto.ViewCount = 0;

            var blogValues = _mapper.Map<Blog>(createBlogDto);
            _blogService.TInsert(blogValues);

            return RedirectToAction("MyBlogList", "Blog", new {area="User"});
		}


    }
}
