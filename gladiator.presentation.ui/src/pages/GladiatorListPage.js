import { useEffect } from "react";
import { Link } from "react-router-dom";
import DeleteButton from "../Components/DeleteButton";
import useFetchCallback from "../hooks/useFetchCallback";
import LoadingSpinner from "../Components/LoadingSpinner";

const GladiatorListPage = () => {
    const {
        isLoading,
        data: gladiators,
        fetchError,
        fetchApi,
    } = useFetchCallback(
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
        return <LoadingSpinner>({fetchError})</LoadingSpinner>;
    }

    return (
        <div>
            <h2>Gladiator List</h2>

            {gladiators &&
                gladiators.map((gladiator) => (
                    <div key={gladiator.id} className="row mb-3">
                        <span className="col-4">{gladiator.name}</span>
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
                        <DeleteButton
                            value="Delete"
                            url={`/api/gladiator/${gladiator.id}`}
                            navigateTo={0}
                            className="mx-3 col"
                        />
                    </div>
                ))}
            <div>
                <Link
                    to={`/gladiator/create`}
                    className="btn btn-secondary col"
                >
                    Create
                </Link>
            </div>
        </div>
    );
};

export default GladiatorListPage;
