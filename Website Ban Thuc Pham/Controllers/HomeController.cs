using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Website_Ban_Thuc_Pham.Models;
using Website_Ban_Thuc_Pham.Models.Authentication;

namespace Website_Ban_Thuc_Pham.Controllers
{
    public class HomeController : Controller
    {
        Bantraicayraucu1Context db = new Bantraicayraucu1Context();
        private readonly ILogger<HomeController> _logger;
        private readonly Bantraicayraucu1Context _context;

        public HomeController(ILogger<HomeController> logger, Bantraicayraucu1Context context)
        {
            _logger = logger;
            _context = context;
        }
        [Authentication]
        public IActionResult Index()
        {
            var lstsanpham = db.SanPhams.ToList();
            return View(lstsanpham);
        }

        public IActionResult SanPhamTheoloai(string maloai)
        {
            List<SanPham> lstsanpham = db.SanPhams.Where
                (x=>x.MaLoai==maloai).OrderBy(x=>x.TenSp).ToList();
            return View(lstsanpham);
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/post-{slug}-{id:long}.html", Name = "Details")]
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _context.Posts.FirstOrDefault(m => (m.PostID == id) && (m.IsActive == true));
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}