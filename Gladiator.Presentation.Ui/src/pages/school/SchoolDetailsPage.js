import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Link } from "react-router-dom";
import useFetchCallback from "../../hooks/useFetchCallback";
import LoadingSpinner from "../../Components/LoadingSpinner";

const SchoolDetailsPage = () => {
    const { id } = useParams();
    const {
        isLoading,
        data: school,
        fetchError,
        fetchApi,
    } = useFetchCallback(
        `/api/school/${id}`,
        "GET",
        { "Content-Type": "application/json" },
        null,
        null
    );

    useEffect(() => {
        fetchApi();
    }, [id]);

    if (isLoading || fetchError) {
        return <LoadingSpinner>({fetchError})</LoadingSpinner>;
    }

    return (
        <div>
            <h1>{school.name}</h1>

            <div className="mb-3">
                <Link
                    to={`/school/edit/${school.id}`}
                    className="btn btn-secondary mx-3 col"
                >
                    Edit
                </Link>

                <h2>Gladiators</h2>
                {school.gladiators &&
                    school.gladiators.map((gladiator) => (
                        <div key={gladiator.id}>
                            <p className="col">
                                <span>{gladiator.name}</span>
                            </p>
                        </div>
                    ))}
                {!school.gladiators && (
                    <div className="mb-3">
                        No gladiators yet in this school!
                    </div>
                )}
            </div>
            <Link to="/school" className="btn btn-secondary m-3 col">
                Back
            </Link>
        </div>
    );
};

export default SchoolDetailsPage;
