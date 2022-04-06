import { Link } from "react-router-dom";
import useFetch from "../../hooks/useFetch";

const SchoolListPage = () => {
    const { isLoading, data: schools, fetchError } = useFetch("/api/school");

    if (isLoading || fetchError) {
        return <span>Loading...({fetchError})</span>;
    }

    return (
        <div>
            <h2>School List</h2>

            {schools &&
                schools.map((school) => (
                    <div key={school.id} className="mb-3">
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
                        <Link
                            to={`/school/delete/${school.id}`}
                            className="btn btn-secondary mx-3 col"
                        >
                            Delete
                        </Link>
                    </div>
                ))}
        </div>
    );
};

export default SchoolListPage;