using System;
using System.Collections.Generic;

namespace Website_Ban_Thuc_Pham.Models;

public partial class SanPham
{
    public long MaSp { get; set; }

    public string? TenSp { get; set; }

    public long MaDmuc { get; set; }

    public string? AnhSp { get; set; }

    public decimal? Price { get; set; }

    public string? Mtsp { get; set; }

    public string? MaLoai { get; set; }

    public virtual LoaiSp? MaLoaiNavigation { get; set; }
}
