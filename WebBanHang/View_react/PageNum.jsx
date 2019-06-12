const PageNumber = ({ num, active, gotoPage }) => {
    if (active) {
        return (<li className="page-item active">
            <a className="page-link" >{num}</a>
        </li>);

    }
    return (<li className="page-item">
        <a className="page-link" onClick={()=>gotoPage(num)} >{num}</a>
    </li>);
}