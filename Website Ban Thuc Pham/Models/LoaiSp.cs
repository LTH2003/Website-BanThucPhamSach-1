using System;
using System.Collections.Generic;

namespace Website_Ban_Thuc_Pham.Models;

public partial class LoaiSp
{
    public string MaLoai { get; set; } = null!;

    public string? Loai { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
