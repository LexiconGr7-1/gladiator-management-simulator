import { useEffect } from "react";
import useFetchCallback from "../../hooks/useFetchCallback";
import LoadingSpinner from "../LoadingSpinner";
import GladiatorAccordion from "./GladiatorAccordion";

const GladiatorOpponents = (props) => {
    const { opponentId, setSelected } = props;

    const {
        isLoading,
        data: gladiators,
        fetchError,
        fetchApi,
    } = useFetchCallback(
        "/api/battle/opponents/gladiator/" + opponentId,
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
        <GladiatorAccordion gladiators={gladiators} setSelceted={setSelected} />
    );
};

export default GladiatorOpponents;
