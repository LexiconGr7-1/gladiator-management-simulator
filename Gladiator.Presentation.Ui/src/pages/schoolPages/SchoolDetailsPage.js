import { useParams } from "react-router-dom";
import { Link } from "react-router-dom";
import useFetch from "../../hooks/useFetch";

const SchoolDetailsPage = () => {
    const { id } = useParams();
    const { isLoading, data: school, fetchError } = useFetch(`/api/school/${id}`);

    if (isLoading || fetchError) {
        return <span>Loading...({fetchError})</span>;
    }

    return (
        <div>
            <h1>{school.name}</h1>

            <div className="mb-3">
                <Link
                    to={`/player/edit/${school.id}`}
                    className="btn btn-secondary mx-3 col"
                >
                    Edit
                </Link>

                <h2>Gladiators</h2>
                {school.gladiators && school.gladiators.map((gladiator => (
                    <div key={gladiator.id}>
                        <p className="col"><span>{gladiator.name}</span></p>
                    </div>
                )))}
            </div>
            <Link to="/school" className="btn btn-secondary m-3 col">
                Back
            </Link>
        </div>

    );
};

export default SchoolDetailsPage;