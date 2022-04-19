import { useEffect } from "react";
import { Link } from "react-router-dom";
import useFetchCallback from "../../hooks/useFetchCallback";
import DeleteButton from "../../Components/DeleteButton";
import LoadingSpinner from "../../Components/LoadingSpinner";

const SchoolListPage = () => {
    const {
        isLoading,
        data: schools,
        fetchError,
        fetchApi,
    } = useFetchCallback(
        "/api/school",
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
            <h2>School List</h2>

            {schools &&
                schools.map((school) => (
                    <div key={school.id} className="row mb-3">
                        <span className="col">{school.name}</span>
                        <Link
                            to={`/school/${school.id}`}
                            className="btn btn-secondary mx-3 col"
                        >
                            Details
                        </Link>

                        <Link
                            to={`/school/edit/${school.id}`}
                            className="btn btn-secondary mx-3 col"
                        >
                            Edit
                        </Link>
                        <DeleteButton
                            value="Delete"
                            url={`/api/school/${school.id}`}
                            navigateTo={0}
                            className="mx-3 col"
                        />
                    </div>
                ))}
            <Link to={`/school/create`} className="btn btn-secondary col">
                Create
            </Link>
        </div>
    );
};

export default SchoolListPage;
