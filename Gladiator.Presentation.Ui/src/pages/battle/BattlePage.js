const BattlePage = () => {

    return (
        <div className="row">
            <div className="col">
                <div className="accordion" id="gladiatorsOpenPanel">
                    <div className="accordion-item">
                        <h2 className="accordion-header" id="panelsStayOpen-headingOne">
                            <button className="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseOne" aria-expanded="true" aria-controls="panelsStayOpen-collapseOne">
                                Accordion Item #1
                            </button>
                        </h2>
                        <div id="panelsStayOpen-collapseOne" className="accordion-collapse collapse show" aria-labelledby="panelsStayOpen-headingOne">
                            <div className="accordion-body">
                                <ul>
                                    <li>Health: 10</li>
                                    <li>Strenght: 10</li>
                                    <li>School: 10</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="col">Opponent</div>
        </div>
    );
}
export default BattlePage;