import { useEffect } from "react";
import useFetchCallback from "../../hooks/useFetchCallback";
import LoadingSpinner from "../../Components/LoadingSpinner";

const BattlePage = () => {
    //const { gladiatorId, setGladiatorId } = useState();
    //const { gladiatorId, setGladiatorId } = useState();

    const {
        isLoading,
        data: gladiators,
        fetchError,
        fetchApi,
    } = useFetchCallback(
        `/api/battle/roster/player/${1}`,
        "GET",
        { "Content-Type": "application/json" },
        null,
        null
    );

    useEffect(() => {
        fetchApi();
    }, []);

    if (isLoading || fetchError) {
        return <LoadingSpinner>({fetchError})</LoadingSpinner>;
    }
    return (
        <div className="row">
            <div className="col">
                <div
                    className="accordion accordion-flush"
                    id="gladiatorsOpenPanel"
                >
                    {gladiators &&
                        gladiators.map((gladiator) => (
                            <div
                                key={gladiator.gladiator.id}
                                className="accordion-item"
                            >
                                <h2
                                    className="accordion-header"
                                    id="flush-headingOne"
                                >
                                    <button
                                        className="accordion-button collapsed"
                                        type="button"
                                        data-bs-toggle="collapse"
                                        data-bs-target="#flush-collapseOne"
                                        aria-expanded="false"
                                        aria-controls="flush-collapseOne"
                                    >
                                        {gladiator.gladiator.name}
                                    </button>
                                </h2>
                                <div
                                    id="flush-collapseOne"
                                    className="accordion-collapse collapse"
                                    aria-labelledby="flush-headingOne"
                                    data-bs-parent="#accordionFlushExample"
                                >
                                    <div className="accordion-body">
                                        <ul>
                                            <li>
                                                Health: {gladiator.gladiator.health}
                                            </li>
                                            <li>
                                                Strength: {gladiator.gladiator.strength}
                                            </li>
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
};
export default BattlePage;
