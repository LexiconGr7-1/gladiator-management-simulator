import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Link } from "react-router-dom";
import LoadingSpinner from "../../Components/LoadingSpinner";
import useFetchCallback from "../../hooks/useFetchCallback";

const ArenaDetailsPage = () => {
    const { id } = useParams();

    const {
        isLoading,
        data: arena,
        fetchError,
        fetchApi,
    } = useFetchCallback(
        `/api/arena/${id}`,
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
            <h2>{arena.name}</h2>

            <div className="row mb-3">
                <div className="col">
                    <h4>Schools</h4>
                    {arena.schools &&
                        arena.schools.map((school) => (
                            <div className="mb-3" key={`s-${school.id}`}>
                                <Link to={`/school/${school.id}`}>
                                    <h5>{school.name}</h5>
                                </Link>
                                {school.gladiators &&
                                    school.gladiators.map((gladiator) => (
                                        <div key={`g-${gladiator.id}`}>
                                            <Link
                                                className="ms-3"
                                                to={`/gladiator/${gladiator.id}`}
                                            >
                                                {gladiator.name}
                                            </Link>
                                        </div>
                                    ))}
                            </div>
                        ))}
                    {!arena.schools && (
                        <div className="mb-3">
                            No schools yet in this arena!
                        </div>
                    )}
                </div>

                <div className="col">
                    <h4>All Gladiators</h4>
                    {arena.gladiators ? (
                        <div></div>
                    ) : (
                        <div>No gladiators yet in this arena!</div>
                    )}
                    {arena.gladiators &&
                        arena.gladiators.map((gladiator) => (
                            <div key={`g2-${gladiator.id}`}>
                                <Link to={`/gladiator/${gladiator.id}`}>
                                    {gladiator.name}
                                </Link>
                            </div>
                        ))}
                </div>
            </div>

            <Link
                to={`/arena/edit/${arena.id}`}
                className="btn btn-secondary mb-3"
            >
                Edit
            </Link>
            <br />
            <Link to="/arena" className="btn btn-secondary">
                Back
            </Link>
        </div>
    );
};

export default ArenaDetailsPage;
