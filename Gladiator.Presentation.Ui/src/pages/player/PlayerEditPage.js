import { Link, useParams } from "react-router-dom";
import LoadingSpinner from "../../Components/LoadingSpinner";
import useFetchCallback from "../../hooks/useFetchCallback";
import { useEffect, useState } from "react";
import EditButton from "../../Components/EditButton";

const PlayerEditPage = () => {
    const { id } = useParams();
    const [name, setName] = useState("");

    // get callback and state
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

    // fetch gladiator
    useEffect(() => {
        fetchApi();
    }, [id]);

    // set states
    useEffect(() => {
        if (player) {
            setName(player.name);
        }
    }, [player, id]);

    if (isLoading || fetchError) {
        return <LoadingSpinner>({fetchError})</LoadingSpinner>;
    }
    console.log(player);
    return (
        <div>
            <h2>Edit {player.name}</h2>
            <form>
                <label htmlFor="name" className="form-label">
                    Name
                </label>
                <input
                    type="text"
                    name="name"
                    className="form-control mb-3"
                    required
                    defaultValue={player.name}
                    onChange={(e) => setName(e.target.value)}
                />
                <EditButton
                    value="Update"
                    url={`/api/player/${player.Id}`}
                    navigateTo={"/player"}
                    body={{ name }}
                    className="mb-3 col"
                />
            </form>
            <Link to="/player" className="btn btn-secondary mb-3 col">
                Back
            </Link>
        </div>
    );
};

export default PlayerEditPage;
