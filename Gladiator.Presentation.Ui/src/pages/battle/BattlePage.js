import { useEffect, useState } from "react";
import useFetchCallback from "../../hooks/useFetchCallback";
import LoadingSpinner from "../../Components/LoadingSpinner";
import GladiatorAccordion from "../../Components/gladiator/GladiatorAccordion";

const BattlePage = () => {
    //const { gladiatorId, setGladiatorId } = useState();
    //const { gladiatorId, setGladiatorId } = useState();
    const [selectedGladiator, setSelectedGladiator] = useState(0);
    const [selectedOpponent, setSelectedOpponent] = useState(0);
    console.log(selectedGladiator);

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
                <h4>Gladiators</h4>
                <GladiatorAccordion
                    gladiators={gladiators}
                    setSelected={setSelectedGladiator}
                />
            </div>
            <div className="col">Opponent {selectedGladiator}</div>
        </div>
    );
};
export default BattlePage;
