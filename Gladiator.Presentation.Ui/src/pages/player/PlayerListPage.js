import { useEffect } from "react";
import { Link } from "react-router-dom";
import DeleteButton from "../../Components/DeleteButton";
import LoadingSpinner from "../../Components/LoadingSpinner";
import useFetchCallback from "../../hooks/useFetchCallback";

const PlayerListPage = () => {
    const {
        isLoading,
        data: players,
        fetchError,
        fetchApi,
    } = useFetchCallback(
        "/api/player",
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
        <div>
            <h2>Player List</h2>

            {players &&
                players.map((player) => (
                    <div key={player.Id} className="row mb-3">
                        <span className="col-4">{player.name}</span>
                        <Link
                            to={`/player/${player.Id}`}
                            className="btn btn-secondary mx-3 col"
                        >
                            Details
                        </Link>

                        <Link
                            to={`/player/edit/${player.Id}`}
                            className="btn btn-secondary mx-3 col"
                        >
                            Edit
                        </Link>
                        <DeleteButton
                            value="Delete"
                            url={`/api/player/${player.Id}`}
                            navigateTo={0}
                            className="mx-3 col"
                        />
                    </div>
                ))}
            <div>
                <Link to={`/player/create`} className="btn btn-secondary col">
                    Create
                </Link>
            </div>
        </div>
    );
};

export default PlayerListPage;
