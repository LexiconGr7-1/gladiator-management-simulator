import { useParams } from "react-router-dom";
import { Link } from "react-router-dom";
import useFetch from "../hooks/useFetch";

const PlayerDetailsPage = () => {
    const { id } = useParams();
    const { isLoading, data: player, fetchError } = useFetch(`/api/player/${id}`);

    if (isLoading || fetchError) {
        return <span>Loading...({fetchError})</span>;
    }

    return (
        <div>
            <h1>Welcome { player.name}!</h1>

            <div className="mb-3">
                <Link
                    to={`/player/edit/${player.Id}`}
                    className="btn btn-secondary mx-3 col"
                >
                    Edit
                </Link>

                <h2>Schools</h2>
                {player.schools && player.schools.map((school => (
                    <div key={school.id}>
                        <p className="col"><span>{school.name}</span></p>
                        <div>
                            <h5>Gladiators</h5>
                            {school.Gladiators &&
                                school.Gladiators.map((gladiator) => (
                                    <p key={gladiator.id}><span>{ gladiator.name }</span></p>
                                ))
                            }
                        </div>
                    </div>
                    ))
                )}
            </div>
            <Link to="/player" className="btn btn-secondary m-3 col">
                Back
            </Link>
        </div>

    );
}

export default PlayerDetailsPage;