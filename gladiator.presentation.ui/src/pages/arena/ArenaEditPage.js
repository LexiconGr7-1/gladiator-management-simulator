import { useParams } from "react-router-dom";
import useFetch from "../../hooks/useFetch";

const ArenaEditPage = () => {
    const { id } = useParams();
    const {
        isLoading,
        data: arena,
        fetchError,
    } = useFetch(`/api/arena/${id}`);

    if (isLoading || fetchError) {
        return <span>Loading edit arena...({fetchError})</span>;
    }

    return (
        <div>
            <h2>Edit {arena.name}</h2>
            <form>
                <label htmlFor="name" className="form-label">
                    Name
                </label>
                <input
                    type="text"
                    name="name"
                    defaultValue={arena.name}
                    className="form-control mb-3"
                />
                <button type="submit" className="btn btn-primary">
                    Update
                </button>
            </form>
        </div>
    );
};

export default ArenaEditPage;
