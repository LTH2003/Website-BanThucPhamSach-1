using Microsoft.AspNetCore.Mvc;
using Website_Ban_Thuc_Pham.Models;
using Website_Ban_Thuc_Pham.Utilities;

namespace Website_Ban_Thuc_Pham.Controllers
{
    public class RegisterController : Controller
    {
        private readonly Bantraicayraucu1Context _context;
        public RegisterController(Bantraicayraucu1Context context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if(user == null)
            {
                return NotFound();
            }
            var check = _context.Users.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null) 
            {
                Functions._MessageEmail = "Duplicate Email!";
                return RedirectToAction("Index", "Register");
            }
            Functions._MessageEmail = string.Empty;
            user.Password = Functions.MD5Password(user.Password);
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}
