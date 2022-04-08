import { Link } from "react-router-dom";
import useFetch from "../../hooks/useFetch";
import LoadingSpinner from "../Components/LoadingSpinner";

const PlayerListPage = () => {
    const { isLoading, data: players, fetchError } = useFetch("/api/player");

    if (isLoading || fetchError) {
        return <LoadingSpinner>({fetchError})</LoadingSpinner>;
    }

    return (
        <div>
            <h2>Player List</h2>

            {players &&
                players.map((player) => (
                    <div key={player.Id} className="mb-3">
                        <span className="col">{player.name}</span>
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
                        <Link
                            to={`/player/delete/${player.Id}`}
                            className="btn btn-secondary mx-3 col"
                        >
                            Delete
                        </Link>
                    </div>
                ))}
        </div>
    );
};

export default PlayerListPage;
