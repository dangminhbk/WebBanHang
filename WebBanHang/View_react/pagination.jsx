const Pager = ({ max, current,gotoPage }) => {
    if (current === 1)
    {
        if (current === max) {
            return (
                <div className="pagination-wrap" aria-label="...">
                    <ul className="pagination">
                        <PageNumber num={current} active={true} />
                    </ul>
                </div>); 
        }
        return (
            <div className="pagination-wrap" aria-label="...">
                <ul className="pagination">
                    <PageNumber num={current} active={true}  />
                    <PageNumber num={current + 1} active={false} gotoPage={gotoPage} />
                </ul>
            </div>);
    }
    if (current === max) {
        return (
            <div className="pagination-wrap" aria-label="...">
                <ul className="pagination">
                    <PageNumber num={current - 1} active={false} gotoPage={gotoPage} />
                    <PageNumber num={current} active={true} />
                </ul>
            </div>);        
    }
    return (
        <div className="pagination-wrap" aria-label="...">
            <ul className="pagination">
                <PageNumber num={current - 1} active={false} gotoPage={gotoPage} />
                <PageNumber num={current} active={true} />
                <PageNumber num={current + 1} active={false} gotoPage={gotoPage}s />
        </ul>
    </div>);
};

