class CuaHang extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            data: [],
            DanhMuc: 10000,
            MauSac: "Đỏ",
            TenSanPham: "",
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
    timKiem(page) {
        this.setState({ searchType: 2 });
        var tenSP = this.state.TenSanPham;
        fetch(`/api/SanPhamAPI/TimKiem?Page=${page}&DanhMuc=${danhMuc}&MauSac=${mauSac}&TenSanPham=${tenSP}&GiaThapNhat=${giaThap}&GiaCaoNhat=${giaCao}`
        ).then(res => res.json())
            .then(list => {
                this.setState({ data: list, searchType: 1, pageNum: 1, DanhMuc: danhMuc });
            })
            .catch(err => {
                console.log(err);
            });
    }
    inputChange() {
        this.setState({
            DanhMuc: this.refs.DanhMuc.value,
            MauSac: this.refs.MauSac.value,
            TenSanPham: this.refs.TenSanPham.value
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
                    this.timKiem(pageToGo);
                    break;
                }
                default: {
                    break;
                }
            }
        }
    }
    priceChange() {
        if (this.refs.minPrice.value > this.refs.maxPrice.value) {
            this.refs.maxPrice.value = this.refs.minPrice.value;
        }
        this.setState({ minPrice: this.refs.minPrice.value });
        this.setState({ maxPrice: this.refs.maxPrice.value });
    }
    render() {
        return (
            <div className="shopping-list">
                <div className="main-header row">                 
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
