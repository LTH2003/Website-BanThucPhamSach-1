using Microsoft.AspNetCore.Mvc;
using Website_Ban_Thuc_Pham.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Website_Ban_Thuc_Pham.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        Bantraicayraucu1Context db = new Bantraicayraucu1Context();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("sanpham")]
        public IActionResult SanPham()
        {
            var lstSanPham = db.SanPhams.ToList();
            return View(lstSanPham);
        }
        [Route("loaisp")]
        public IActionResult LoaiSp()
        { 
            var lstLoaiSp = db.LoaiSps.ToList();
            return View(lstLoaiSp);
        }
        [Route("menu")]
        public IActionResult Menu()
        {
            var lstMenu = db.Menus.ToList();
            return View(lstMenu);
        }
		[Route("user")]
		public new IActionResult User()
		{
			var lstUser = db.Users.ToList();
			return View(lstUser);
		}
		[Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.MaSp = new SelectList(db.SanPhams.ToList(), "MaSp", "SanPham");
            ViewBag.MaLoai = new SelectList(db.LoaiSps.ToList(), "MaLoai", "MaLoai");
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("SanPham");
            }
            return View(sanPham);
        }

        [Route("ThemMenuMoi")]
        [HttpGet]
        public IActionResult ThemMenuMoi()
        {
            ViewBag.MenuId = new SelectList(db.Menus.ToList(), "MenuId", "Menu");
            return View();
        }
        [Route("ThemMenuMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemMenuMoi(Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Menu");
            }
            return View(menu);
        }

        [Route("ThemLoaiSpMoi")]
        [HttpGet]
        public IActionResult ThemLoaiSpMoi()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiSps.ToList(), "MaLoai", "Loai");
            return View();
        }
        [Route("ThemLoaiSpMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemLoaiSpMoi(LoaiSp loaiSp)
        {
            if (ModelState.IsValid)
            {
                db.LoaiSps.Add(loaiSp);
                db.SaveChanges();
                return RedirectToAction("LoaiSp");
            }
            return View(loaiSp);
        }


        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(long MaSp)
        {
            ViewBag.MaSp = new SelectList(db.SanPhams.ToList(), "MaSp", "SanPham");
            ViewBag.MaLoai = new SelectList(db.LoaiSps.ToList(), "MaLoai", "MaLoai");
            var sanPham = db.SanPhams.Find(MaSp);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SanPham", "HomeAdmin");
            }
            return View(sanPham);
        }

        [Route("SuaMenu")]
        [HttpGet]
        public IActionResult SuaMenu(int MenuId)
        {
            ViewBag.MenuId = new SelectList(db.Menus.ToList(), "MenuId", "Menu");
            var menu = db.Menus.Find(MenuId);
            return View(menu);
        }
        [Route("SuaMenu")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaMenu(Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Menu", "HomeAdmin");
            }
            return View(menu);
        }

        [Route("SuaLoaiSp")]
        [HttpGet]
        public IActionResult SuaLoaiSp(string MaLoai)
        {
            ViewBag.MaLoai = new SelectList(db.LoaiSps.ToList(), "MaLoai", "Loai");
            var loaiSp = db.LoaiSps.Find(MaLoai);
            return View(loaiSp);
        }
        [Route("SuaLoaiSp")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaLoaiSp(LoaiSp loaiSp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiSp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LoaiSp", "HomeAdmin");
            }
            return View(loaiSp);
        }

        [Route("XoaSanPham")]
        [HttpGet]

        public IActionResult XoaSanPham(long MaSp)
        {
            TempData["Message"] = "";
            var chiTietSanPhams = db.SanPhams.Where(x => x.MaDmuc == MaSp).ToList();
            if (chiTietSanPhams.Count() > 0)
            {
                TempData["Message"] = "Không được xóa sản phẩm này";
                return RedirectToAction("SanPham", "HomeAdmin");
            }
            var MaSps = db.SanPhams.Where(x => x.MaDmuc == MaSp);
            if (MaSps.Any()) db.RemoveRange(MaSps);
            db.Remove(db.SanPhams.Find(MaSp));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("SanPham", "HomeAdmin");
        }

        [Route("XoaMenu")]
        [HttpGet]

        public IActionResult XoaMenu(int MenuId)
        {
            TempData["Message"] = "";
            var chiTietMenus = db.Menus.Where(x => x.Levels == MenuId).ToList();
            if (chiTietMenus.Count() > 0)
            {
                TempData["Message"] = "Không được xóa menu này";
                return RedirectToAction("Menu", "HomeAdmin");
            }
            var MenuIds = db.Menus.Where(x => x.Levels == MenuId);
            if (MenuIds.Any()) db.RemoveRange(MenuIds);
            db.Remove(db.Menus.Find(MenuId));
            db.SaveChanges();
            TempData["Message"] = "Menu đã được xóa";
            return RedirectToAction("Menu", "HomeAdmin");
        }

        [Route("XoaLoaiSp")]
        [HttpGet]

        public IActionResult XoaLoaiSp(string MaLoai)
        {
            TempData["Message"] = "";
            var chiTietMaLoais = db.LoaiSps.Where(x => x.Loai == MaLoai).ToList();
            if (chiTietMaLoais.Count() > 0)
            {
                TempData["Message"] = "Không được xóa loại sản phẩm này";
                return RedirectToAction("LoaiSp", "HomeAdmin");
            }
            var MaLoais = db.LoaiSps.Where(x => x.Loai == MaLoai);
            if (MaLoais.Any()) db.RemoveRange(MaLoais);
            db.Remove(db.LoaiSps.Find(MaLoai));
            db.SaveChanges();
            TempData["Message"] = "Loại sản phẩm đã được xóa";
            return RedirectToAction("LoaiSp", "HomeAdmin");
        }

		[Route("ThemUser")]
		[HttpGet]
		public IActionResult ThemUser()
		{
			ViewBag.UserID = new SelectList(db.Users.ToList(), "UserID", "User");
			return View();
		}
		[Route("ThemUser")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ThemUser(User user)
		{
			if (ModelState.IsValid)
			{
				db.Users.Add(user);
				db.SaveChanges();
				return RedirectToAction("User");
			}
			return View(user);
		}
		[Route("SuaUser")]
		[HttpGet]
		public IActionResult SuaUser(int UserID)
		{
			ViewBag.UserID = new SelectList(db.Users.ToList(), "UserID", "User");
			var user = db.Users.Find(UserID);
			return View(user);
		}
		[Route("SuaUser")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult SuaUser(User user)
		{
			if (ModelState.IsValid)
			{
				db.Entry(user).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("User", "HomeAdmin");
			}
			return View(user);
		}

		[Route("XoaUser")]
		[HttpGet]

		public IActionResult XoaUser(int UserID)
		{
			TempData["Message"] = "";
			var chiTietUsers = db.Users.Where(x => x.UserID == UserID).ToList();
			if (chiTietUsers.Count() > 0)
			{
				TempData["Message"] = "Không được xóa tài khoản này";
				return RedirectToAction("User", "HomeAdmin");
			}
			var UserIDs = db.Users.Where(x => x.UserID == UserID);
			if (UserIDs.Any()) db.RemoveRange(UserID);
			db.Remove(db.Users.Find(UserID));
			db.SaveChanges();
			TempData["Message"] = "Tài khoản này đã được xóa";
			return RedirectToAction("User", "HomeAdmin");
		}

	}
}
