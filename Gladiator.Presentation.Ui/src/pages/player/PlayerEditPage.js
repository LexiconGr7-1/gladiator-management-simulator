import { useParams } from "react-router-dom";
import useFetch from "../../hooks/useFetch";

const PlayerEditPage = () => {
    const { id } = useParams();
    const {
        isLoading,
        data: player,
        fetchError,
    } = useFetch(`/api/player/${id}`);

    if (isLoading || fetchError) {
        return <span>Loading...({fetchError})</span>;
    }

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
                    defaultValue={player.name}
                    className="form-control mb-3"
                />
                <button type="submit" className="btn btn-primary">
                    Update
                </button>
            </form>
        </div>
    );
};

export default PlayerEditPage;
