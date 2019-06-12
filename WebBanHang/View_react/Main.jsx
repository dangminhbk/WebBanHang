class CuaHang extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            data: [],
            query: {
                DanhMuc: "",
                MauSac: "",
                TenSanPham:"",
                GiaThap: 0,
                GiaCao: 0
            },
            searchAble: false,
            pageNum: 1,
            pageMax: 1
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
                this.setState({ pageMax: data })
            });
    }
    timKiem()
    {

    }
    gotoPage(pageToGo)
    {
        if (pageToGo > 0 && pageToGo <= this.state.pageMax)
        {
            fetch(`/api/SanPhamAPI/GetSanPhams?page=${pageToGo}`)
                .then(data => {
                    return data.json();
                })
                .then(list => {
                    this.setState({ data: list, pageNum: pageToGo });
                })
                .catch(err => {
                    console.log(err);
                });
        }
    }
    render() {
        
        return (
            <div className="shopping-list">
                <div className="main-header row">
                    <input type="text" className="form-control col-md-2" placeholder="Tên sản phẩm" />
                    <select className="form-control col-md-2" >
                        <option>Hoa cưới</option>
                        <option>Hoa cưới</option>
                        <option>Hoa cưới</option>
                        <option>Hoa cưới</option>
                    </select>
                    <button className="form-control col-md-2 btn btn-primary" type="button"  onClick={this.timKiem}>Tim kiếm</button>  
                </div>
                <ul className="main-list">
                    {this.state.data.map(item => <ItemSanPham item={item} /> )}
                </ul>
                <Pager className="main-footer" max={this.state.pageMax} current={this.state.pageNum} gotoPage={this.gotoPage.bind(this)} />
            </div>
        );
    }
}

ReactDOM.render(<CuaHang/>, document.getElementById('react-view'));
