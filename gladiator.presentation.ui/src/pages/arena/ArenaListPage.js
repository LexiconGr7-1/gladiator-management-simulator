import { useEffect } from "react";
import { Link } from "react-router-dom";
import DeleteButton from "../../Components/DeleteButton";
import LoadingSpinner from "../../Components/LoadingSpinner";
import useFetchCallback from "../../hooks/useFetchCallback";

const ArenaListPage = () => {
    const {
        isLoading,
        data: arenas,
        fetchError,
        fetchApi,
    } = useFetchCallback(
        "/api/arena",
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
            <h2>Arena List</h2>

            {arenas &&
                arenas.map((arena) => (
                    <div key={arena.id} className="row mb-3">
                        <span className="col">{arena.name}</span>
                        <Link
                            to={`/arena/${arena.id}`}
                            className="btn btn-secondary mx-3 col"
                        >
                            Details
                        </Link>

                        <Link
                            to={`/arena/edit/${arena.id}`}
                            className="btn btn-secondary mx-3 col"
                        >
                            Edit
                        </Link>
                        <DeleteButton
                            value="Delete"
                            url={`/api/arena/${arena.id}`}
                            navigateTo={0}
                            className="mx-3 col"
                        />
                    </div>
                ))}
            <div>
                <Link to={`/arena/create`} className="btn btn-secondary col">
                    Create
                </Link>
            </div>
        </div>
    );
};

export default ArenaListPage;
