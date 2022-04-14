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

            <Link to={`/arena/edit/${arena.id}`} className="btn btn-secondary">
                Edit
            </Link>

            <div className="row">
                <div className="col">
                    <h4>Schools</h4>
                    {arena.schools &&
                        arena.schools.map((school) => (
                            <div key="{school.id}">
                                <Link to={`/school/${school.id}`}>
                                    <h5>{school.name}</h5>
                                </Link>
                                {school.Gladiators &&
                                    school.Gladiators.map((gladiator) => (
                                        <div key="{gladiator.id}">
                                            <Link
                                                to={`/gladiator/${gladiator.id}`}
                                            >
                                                {gladiator.name}
                                            </Link>
                                        </div>
                                    ))}
                            </div>
                        ))}
                </div>

                <div className="col">
                    <h4>All Gladiators</h4>
                    {arena.gladiators &&
                        arena.gladiators.map((gladiator) => (
                            <div key="{gladiator.id}">
                                <Link to={`/gladiator/${gladiator.id}`}>
                                    {gladiator.name}
                                </Link>
                            </div>
                        ))}
                </div>
            </div>

            <Link to="/arena" className="btn btn-secondary">
                Back
            </Link>
        </div>
    );
};

export default ArenaDetailsPage;
