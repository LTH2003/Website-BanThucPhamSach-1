using Website_Ban_Thuc_Pham.Models;
using Microsoft.AspNetCore.Mvc;
using Website_Ban_Thuc_Pham.Reponsitory;

namespace Website_Ban_Thuc_Pham.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly ILoaiSpReponsitory _loaiSp;
        public LoaiSpMenuViewComponent(ILoaiSpReponsitory _loaiSpReponsitory)
        {
            _loaiSp = _loaiSpReponsitory;
        }
        public IViewComponentResult Invoke()
        {
            var loaisp = _loaiSp.GetAllLoaiSp().OrderBy(x=>x.Loai).ToList();
            return View(loaisp);
        }
    }
}
