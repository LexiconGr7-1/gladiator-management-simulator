import { useEffect } from "react";
import { Link } from "react-router-dom";
//import useFetch from "../hooks/useFetch";
import useFetchCallback from "../hooks/useFetchCallback";

const GladiatorListPage = () => {
    //const { isLoading, data: gladiators, fetchError } = useFetch("/api/gladiator");
    //

    const { isLoading, data: gladiators, fetchError, fetchApi } = useFetchCallback(
        "/api/gladiator",
        "GET",
        { "Content-Type": "application/json" },
        null,
        null
    );

    useEffect(() => {
        fetchApi();
    }, []);

    if (isLoading || fetchError) {
        return <span>Loading...({fetchError})</span>;
    }

    return (
        <div>
            <h2>Gladiator List</h2>

            {gladiators &&
                gladiators.map((gladiator) => (
                    <div key={gladiator.id} className="mb-3">
                        <span className="col">{gladiator.name}</span>
                        <Link
                            to={`/gladiator/${gladiator.id}`}
                            className="btn btn-secondary mx-3 col"
                        >
                            Details
                        </Link>

                        <Link
                            to={`/gladiator/edit/${gladiator.id}`}
                            className="btn btn-secondary mx-3 col"
                        >
                            Edit
                        </Link>
                        <Link
                            to={`/gladiator/delete/${gladiator.id}`}
                            className="btn btn-secondary mx-3 col"
                        >
                            Delete
                        </Link>
                    </div>
                ))}
            <div>
                <Link
                    to={`/gladiator/create`}
                    className="btn btn-secondary mx-3 col"
                >
                    Create
                </Link>
            </div>
        </div>
    );
};

export default GladiatorListPage;
