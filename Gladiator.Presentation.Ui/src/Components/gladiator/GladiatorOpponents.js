import { useEffect } from "react";
import useFetchCallback from "../../hooks/useFetchCallback";
import LoadingSpinner from "../LoadingSpinner";
import OpponentAccordion from "./OpponentAccordion";

const GladiatorOpponents = (props) => {
    const { selectedGladiator } = props;

    const {
        isLoading,
        data: gladiators,
        fetchError,
        fetchApi,
    } = useFetchCallback(
        "/api/battle/opponents/gladiator/" + 1,
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
        <OpponentAccordion
            gladiators={gladiators}
            selectedGladiator={selectedGladiator}
        />
    );
};

export default GladiatorOpponents;
