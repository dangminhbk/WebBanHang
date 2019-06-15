class CuaHang extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            data: [],
            DanhMuc: "",
            MauSac: "",
            TenSanPham: "",
            GiaThap: 0,
            GiaCao: 0,
            searchType: 0,
            pageNum: 1,
            pageMax: 1,
            minPrice: 0,
            maxPrice: 0

        };
        fetch("/api/SanPhamAPI/GetSanPhams?page=1")
            .then(data => {
                return data.json();
            })
            .then(list => {
                this.setState({ data: list });
            })
            .catch(err => {
                console.log(err);
            });
        fetch("/api/SanPhamAPI/SoLuongTrang")
            .then(res => res.json())
            .then(data => {
                this.setState({ pageMax: data });
            });
    }
    timKiemDanhMuc(danhMuc) {
        fetch(`/api/SanPhamAPI/SanPhamDanhMuc?page=1&DanhMuc=${danhMuc}`)
            .then(data => {
                return data.json();
            })
            .then(list => {
                this.setState({ data: list, searchType: 1, pageNum: 1, DanhMuc: danhMuc });
            })
            .catch(err => {
                console.log(err);
            });
        fetch(`/api/SanPhamAPI/SoLuongTrangTheoDanhMuc?DanhMuc=${danhMuc}`)
            .then(res => res.json())
            .then(data => {
                this.setState({ pageMax: data });
            })
            .catch(err => {
                console.log(err);
            });
    }
    gotoPage(pageToGo) {
        if (pageToGo > 0 && pageToGo <= this.state.pageMax) {
            switch (this.state.searchType) {
                case 0: {
                    fetch(`/api/SanPhamAPI/GetSanPhams?page=${pageToGo}`)
                        .then(data => {
                            return data.json();
                        })
                        .then(list => {
                            this.setState({ data: list, pageNum: pageToGo, searchType: 0 });
                        })
                        .catch(err => {
                            console.log(err);
                        });
                    break;
                }
                case 1: {
                    fetch(`/api/SanPhamAPI/SanPhamDanhMuc?page=${pageToGo}&DanhMuc=${this.state.DanhMuc}`)
                        .then(data => {
                            return data.json();
                        })
                        .then(list => {
                            this.setState({ data: list, pageNum: pageToGo, searchType: 1 });
                        })
                        .catch(err => {
                            console.log(err);
                        });
                    break;
                }
                case 2: {
                    break;
                }
                default: {
                    break;
                }
            }
        }
    }
    priceChange() {
        if (this.refs.minPrice.value > this.refs.maxPrice.value)
        {
            this.refs.maxPrice.value = this.refs.minPrice.value;
        }
        this.setState({ minPrice: this.refs.minPrice.value });
        this.setState({ maxPrice: this.refs.maxPrice.value });
    }
    render() {
        return (
            <div className="shopping-list">
                <div className="main-header row">
                    <input type="text" className="form-control col-md-3" placeholder="Tên sản phẩm" />
                    <select className="form-control col-md-2" >
                        <option>Hoa đám cưới</option>
                        <option>Hoa đám ma</option>
                        <option>Điện hoa</option>
                        <option>Hoa sinh nhật</option>

                    </select>
                    <select className="form-control col-md-2" >

                    </select>
                    <button className="form-control col-md-2 btn btn-primary" type="button" onClick={this.timKiem}>Tim kiếm</button>
                    <div className="col-md-12 price-row">
                        <div className="col-md-12 slider-wrap">
                            <label>Gia thấp nhất</label>
                            <input step={1000} ref="minPrice" className="slider" type="range" min={0} max={1000000} onChange={() => this.priceChange()} />
                            <label>{this.state.minPrice} vnd</label>   
                        </div>
                        <div className="col-md-12 slider-wrap">
                            <label>Giá cáo nhất</label>   
                            <input step={1000} ref="maxPrice" className="slider" type="range" min={this.state.minPrice} max={1000000} onChange={() => this.priceChange()} />
                            <label>{this.state.maxPrice} vnd</label>   
                        </div>
                    </div>
                </div>
                <ul className="main-list">
                    {this.state.data.map(item => <ItemSanPham item={item} />)}
                </ul>
                <Pager className="main-footer" max={this.state.pageMax} current={this.state.pageNum} gotoPage={this.gotoPage.bind(this)} />
            </div>
        );
    }
}

var cuaHang = ReactDOM.render(<CuaHang />, document.getElementById('react-view'));
