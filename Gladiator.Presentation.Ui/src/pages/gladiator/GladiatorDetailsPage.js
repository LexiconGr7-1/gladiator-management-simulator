import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Link } from "react-router-dom";
import useFetchCallback from "../../hooks/useFetchCallback";
import LoadingSpinner from "../../Components/LoadingSpinner";

const GladiatorDetailsPage = () => {
    const { id } = useParams();

    const {
        isLoading,
        data: gladiator,
        fetchError,
        fetchApi,
    } = useFetchCallback(
        `/api/gladiator/${id}`,
        "GET",
        { "Content-Type": "application/json" },
        null,
        null
    );

    useEffect(() => {
        fetchApi();
    }, [id]);

    if (isLoading || fetchError) {
        return <LoadingSpinner>({fetchError})</LoadingSpinner>;
    }

    return (
        <div>
            <h2>{gladiator.name}</h2>
            <div className="mb-3 row">
                <label className="col">Name</label>
                <span className="col"> {gladiator.name} </span>
            </div>
            <div className="mb-3 row">
                <label className="col">Health</label>
                <span className="col"> {gladiator.health} </span>
            </div>
            <div className="mb-3 row">
                <label className="col">Strength</label>
                <span className="col"> {gladiator.strength} </span>
            </div>
            <Link to="/gladiator" className="btn btn-secondary mb-3 col">
                Back
            </Link>
        </div>
    );
};

export default GladiatorDetailsPage;
