const ItemSanPham = ({item}) =>
(
    <li className="sanpham">
        <a href={"/CuaHang/Details/" + item.MaSanPham}>
                <div className="image-wrap">
                    <img src={item.anhHienThi === "" ? "/Image/speedwell.jpg" : item.anhHienThi} />
                    <span className="giohang-icon hidden-icon">
                        {null}
                </span>
                    <span className="view-icon hidden-icon">
                        {null}
                </span>
            </div>
                <label className="sanpham-name">{item.TenSanPham} </label>
                <label className="sanpham-price">Giá sản phẩm: {item.GiaSanPham} vnd</label>
                <label className="sanpham-price">{item.GiaKhuyenMai === item.GiaSanPham ? " " : `Khuyến mại: ${item.GiaKhuyenMai} vnd` }</label>

        </a>
    </li>
);