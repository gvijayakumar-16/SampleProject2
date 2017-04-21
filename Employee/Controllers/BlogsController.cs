using AutoMapper;
using Employee.Domain.Services;
using Employee.DTO;
using Employee.Helpers;
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
        /// Get the details of blogs
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var blog = await _context.Blog
        //        .SingleOrDefaultAsync(m => m.BlogId == id);
        //    if (blog == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(blog);
        //}

        /// <summary>
        /// Create a new blog
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create([FromBody][Bind("BlogId,Url")] BlogDTO blog)
        {
            if (ModelState.IsValid)
            {
                ServiceManager.BlogService.Save(blog);
                if (Request.IsAjaxRequest()) return Json("Blog Added Successfully");
                return RedirectToAction("Index");
            }
            if (Request.IsAjaxRequest())
            {
                return Json("Blog Not Inserted! Try Again");
            }
            return View(blog);
        }

        //// GET: Blogs/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var blog = await _context.Blog.SingleOrDefaultAsync(m => m.BlogId == id);
        //    if (blog == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(blog);
        //}


        [HttpPost]
        public IActionResult Edit([FromBody][Bind("BlogId,Url")] BlogDTO blog)
        {
            if (ModelState.IsValid)
            {
                ServiceManager.BlogService.Save(blog);
                if (Request.IsAjaxRequest()) return Json("Blog Updated Successfully");
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        //// GET: Blogs/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var blog = await _context.Blog
        //        .SingleOrDefaultAsync(m => m.BlogId == id);
        //    if (blog == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(blog);
        //}

        //// POST: Blogs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var blog = await _context.Blog.SingleOrDefaultAsync(m => m.BlogId == id);
        //    _context.Blog.Remove(blog);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //private bool BlogExists(int id)
        //{
        //    return _context.Blog.Any(e => e.BlogId == id);
        //}
    }
}
