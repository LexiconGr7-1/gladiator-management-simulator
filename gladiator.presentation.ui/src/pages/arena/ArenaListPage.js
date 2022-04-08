import { Link } from "react-router-dom";
import useFetch from "../../hooks/useFetch";

const ArenaListPage = () => {
    const { isLoading, data: arenas, fetchError } = useFetch("/api/arena");

    if (isLoading || fetchError) {
        return <span>Loading...({fetchError})</span>;
    }
    console.log(arenas);

    return (
        <div>
            <h2>Arena List</h2>

            {arenas &&
                arenas.map((arena) => (
                    <div key={arena.id} className="mb-3">
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
                        <Link
                            to={`/arena/delete/${arena.id}`}
                            className="btn btn-secondary mx-3 col"
                        >
                            Delete
                        </Link>
                    </div>
                ))}
            <div>
                <Link
                    to={`/arena/create`}
                    className="btn btn-secondary col"
                >
                    Create
                </Link>
            </div>
        </div>
    );
};

export default ArenaListPage;
