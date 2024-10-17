using MessagePack;
using System;
using System.Collections.Generic;

namespace Website_Ban_Thuc_Pham.Models
{
    public class ChiTietSanPham
    {
        [Key]
        public string? MaChiTietSP { get; set; }

        public long MaSp {  get; set; }

        public string? AnhSP { get; set; }

        public decimal? Price { get; set; }

        public float? GiamGia { get; set; }

        public int? SLTon { get; set; }
    }
}
