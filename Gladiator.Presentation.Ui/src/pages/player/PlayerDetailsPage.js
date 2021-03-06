import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Link } from "react-router-dom";
import LoadingSpinner from "../../Components/LoadingSpinner";
import useFetchCallback from "../../hooks/useFetchCallback";

const PlayerDetailsPage = () => {
    const { id } = useParams();

    const {
        isLoading,
        data: player,
        fetchError,
        fetchApi,
    } = useFetchCallback(
        `/api/player/${id}`,
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
            <h2>{player.name}</h2>

            <Link
                to={`/player/edit/${player.Id}`}
                className="btn btn-secondary"
            >
                Edit
            </Link>

            <div className="row">
                <div className="col">
                    <h4>Schools</h4>
                    {player.schools &&
                        player.schools.map((school) => (
                            <div key="{school.id}">
                                <Link to={`/school/${school.id}`}>
                                    <h5>{school.name}</h5>
                                </Link>
                                {school.Gladiators &&
                                    school.Gladiators.map((gladiator) => (
                                        <div key="{gladiator.id}">
                                            <Link
                                                to={`/gladiator/${gladiator.id}`}
                                            >
                                                {gladiator.name}
                                            </Link>
                                        </div>
                                    ))}
                            </div>
                        ))}
                </div>

                <div className="col">
                    <h4>All Gladiators</h4>
                    {player.gladiators &&
                        player.gladiators.map((gladiator) => (
                            <div key="{gladiator.id}">
                                <Link to={`/gladiator/${gladiator.id}`}>
                                    {gladiator.name}
                                </Link>
                            </div>
                        ))}
                </div>
            </div>

            <Link to="/player" className="btn btn-secondary">
                Back
            </Link>
        </div>
    );
};

export default PlayerDetailsPage;
