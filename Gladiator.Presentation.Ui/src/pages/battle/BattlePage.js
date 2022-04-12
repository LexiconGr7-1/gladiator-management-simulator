import { useEffect, useState } from "react";
import useFetchCallback from "../../hooks/useFetchCallback";
import LoadingSpinner from "../../Components/LoadingSpinner";

const BattlePage = (props) => {
    const { gladiatorId, setGladiatorId } = useState();

    const { isLoading, data: gladiators, fetchError, fetchApi } = useFetchCallback(
        `/api/battle/roster/player/${props.playerId}`,
        "GET",
        { "Content-Type": "application/json" },
        null,
        null
    );

    useEffect(() => {
        fetchApi();
    }, [props.playerId]);

    if (isLoading || fetchError) {
        return <LoadingSpinner>({fetchError})</LoadingSpinner>;
    }
    return (
        <div className="row">
            <div className="col">
                <div className="accordion" id="gladiatorsOpenPanel">
                    {gladiators &&
                        gladiators.map((gladiator) => (
                            <div key={gladiator.gladiator.id} className="accordion-item">
                                <h2 className="accordion-header" id="panelsStayOpen-headingOne">
                                    <button className="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseOne" aria-expanded="true" aria-controls="panelsStayOpen-collapseOne">
                                        
                                    </button>
                                </h2>
                                <div id="panelsStayOpen-collapseOne" className="accordion-collapse collapse show" aria-labelledby="panelsStayOpen-headingOne">
                                    <div className="accordion-body">
                                        <ul>
                                            <li>Health: {gladiator.gladiator.health}</li>
                                            <li>Strength: {gladiator.gladiator.strength}</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                    ))}
                </div>
            </div>
            <div className="col">Opponent</div>
        </div>
    );
}
export default BattlePage;