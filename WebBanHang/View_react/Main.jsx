class CuaHang extends React.Component {
    constructor(props) {
        super(props);
        this.state = {data:[]};
        fetch("/api/SanPhamAPI?page=1")
            .then(data => {
                return data.json();
            })
            .then(list => {
                this.setState({ data: list });
            })
            .catch(err => {
                console.log(err);
            });
    }
    timKiem()
    {

    }
    nextPage()
    {

    }
    prevPage()
    {

    }
    render() {
        return (
            <div className="shopping-list">
                <div>
                    <input type="text" />
                    <input type="text" />
                    <button onClick={this.timKiem}>Tim kiem</button>  
                </div> 
                <ul>
                    {this.state.data.map(item => <ItemSanPham item={item} /> )}
                </ul>
                <Pager max={1} current={1} />
            </div>
        );
    }
}

ReactDOM.render(<CuaHang/>, document.getElementById('react-view'));
