using AutoMapper;
using Employee.Domain.Services;
using Employee.DTO;
using Employee.Helpers;
using Employee.ViewModels.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ServiceManager ServiceManager;
        private readonly ModelManager ModelManager;

        public BlogsController(IMapper mapper, ServiceManager srvMgr, ModelManager mdlMgr)
        {
            _mapper = mapper;
            ServiceManager = srvMgr;
            ModelManager = mdlMgr;
        }

        /// <summary>
        /// List all the blogs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseCache(Duration = 0, NoStore = true)]
        public IActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                var Emp = ServiceManager.BlogService.GetAllBlogs();
                return Json(Emp);
            }
            return View();
        }

        /// <summary>
        /// Create a new blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody][Bind("BlogId,Url")] BlogModel blog)
        {
            if (ModelState.IsValid)
            {
                var domainModel = ModelManager.BlogDTO;
                _mapper.Map(blog, domainModel);
                ServiceManager.BlogService.Save(domainModel);
                if (Request.IsAjaxRequest()) return Json("Blog Added Successfully");
                return RedirectToAction("Index");
            }
            return Json("Blog Not Inserted! Try Again");
        }

        [HttpPost]
        public IActionResult Edit([FromBody][Bind("BlogId,Url")] BlogModel blog)
        {
            if (ModelState.IsValid)
            {
                var domainModel = ModelManager.BlogDTO;
                _mapper.Map(blog, domainModel);
                ServiceManager.BlogService.Save(domainModel);
                if (Request.IsAjaxRequest()) return Json("Blog Updated Successfully");
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        /// <summary>
        /// Delete a blog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed([FromBody]int id)
        {
            ServiceManager.BlogService.Delete(id);
            return Json("Blog Deleted Successfully");
        }
    }
}
