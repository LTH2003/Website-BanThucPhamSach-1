using Website_Ban_Thuc_Pham.Models;
namespace Website_Ban_Thuc_Pham.Reponsitory
{
    public class LoaiSpReponsitory : ILoaiSpReponsitory
    {
        private readonly Bantraicayraucu1Context _context;
        public LoaiSpReponsitory(Bantraicayraucu1Context context)
        {
            _context = context;
        }

        public LoaiSp Add(LoaiSp Loai)
        {
            _context.LoaiSps.Add(Loai);
            _context.SaveChanges();
            return Loai;
        }

        public LoaiSp Delete(string MaLoai)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoaiSp> GetAllLoaiSp()
        {
            return _context.LoaiSps;
        }

        public LoaiSp GetLoaiSp(string MaLoai)
        {
            return _context.LoaiSps.Find(MaLoai);
        }

        public LoaiSp Update(LoaiSp Loai)
        {
            _context.Update(Loai);
            _context.SaveChanges();
            return Loai;
        }
    }
}
