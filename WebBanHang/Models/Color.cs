using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class Color
    {
        public string tenMau { get; set; }
        public string maMau { get; set; }
        public static List<Color> mauCoBan = new List<Color> {
                new Color{maMau = "#f00000", tenMau="Đỏ"},
                new Color{maMau = "#00f000", tenMau="Xanh lá"},
                new Color{maMau = "#0000f0", tenMau="Xanh dương"},
                new Color{maMau = "#800080", tenMau="Tím"},
                new Color{maMau = "#8b0000", tenMau="Đỏ đậm"},
                new Color{maMau = "#FFA500", tenMau="Cam"},
                new Color{maMau = "#EE82EE", tenMau="Hồng"},
                new Color{maMau = "#ffff00", tenMau="Vàng"},
                new Color{maMau = "#ffffff", tenMau="Trắng"},
            };
    }
}