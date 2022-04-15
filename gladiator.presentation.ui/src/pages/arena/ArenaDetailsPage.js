import { useParams } from "react-router-dom";
import { Link } from "react-router-dom";
import useFetch from "../../hooks/useFetch";

const ArenaDetailsPage = () => {
    const { id } = useParams();
    const {
        isLoading,
        data: arena,
        fetchError,
    } = useFetch(`/api/arena/${id}`);

    if (isLoading || fetchError) {
        return <span>Loading arena details...({fetchError})</span>;
    }
    console.log(arena);

    return (
        <div>
            <h2>{arena.name}</h2>

            <Link
                to={`/arena/edit/${arena.id}`}
                className="btn btn-secondary"
            >
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
