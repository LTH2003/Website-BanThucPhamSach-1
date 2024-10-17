using Microsoft.AspNetCore.Mvc;
using Website_Ban_Thuc_Pham.Models;

namespace Website_Ban_Thuc_Pham.Components
{
    [ViewComponent(Name = "Post")]
    public class PostComponent:ViewComponent
    {
        private readonly Bantraicayraucu1Context _context;
        public PostComponent(Bantraicayraucu1Context context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from p in _context.Posts
                              where (p.IsActive == true) && (p.Status == 1)
                              orderby p.PostID descending
                              select p).Take(3).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}
