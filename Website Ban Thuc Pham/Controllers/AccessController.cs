using Microsoft.AspNetCore.Mvc;
using Website_Ban_Thuc_Pham.Models;

namespace Website_Ban_Thuc_Pham.Components
{
    public class AccessController : Controller
    {
        Bantraicayraucu1Context db = new Bantraicayraucu1Context();
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View();
            }    
            else
            {
                return RedirectToAction("Index", "Home");
            }    
        }

        [HttpPost]
        public IActionResult Login(User user) 
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                var u = db.Users.Where(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("Username", u.Username.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login", "Access");
        }
    }
}
