using Website_Ban_Thuc_Pham.Models;
namespace Website_Ban_Thuc_Pham.Reponsitory
{
    public interface ILoaiSpReponsitory
    {
        LoaiSp Add(LoaiSp Loai);
        LoaiSp Update(LoaiSp Loai);
        LoaiSp Delete(string MaLoai);

        LoaiSp GetLoaiSp(string MaLoai);

        IEnumerable<LoaiSp> GetAllLoaiSp();
    }
}
