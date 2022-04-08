import { Link } from "react-router-dom";
import useFetch from "../hooks/useFetch";
import LoadingSpinner from "../Components/LoadingSpinner";

const GladiatorListPage = () => {
    const { isLoading, data: gladiators, fetchError } = useFetch("/api/gladiator");

    if (isLoading || fetchError) {
        return <LoadingSpinner>({fetchError})</LoadingSpinner>;
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
        </div>
    );
};

export default GladiatorListPage;
