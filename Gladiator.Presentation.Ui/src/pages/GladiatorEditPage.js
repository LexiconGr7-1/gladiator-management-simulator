import { useEffect } from "react";
import { useState } from "react";
import { useParams } from "react-router-dom";
import useFetchCallback from "../hooks/useFetchCallback";
import { Link } from "react-router-dom";
import EditButton from "../Components/EditButton";

const GladiatorEditPage = () => {
    const { id } = useParams();
    const [name, setName] = useState("");
    const [health, setHealth] = useState(0);
    const [strength, setStrength] = useState(0);

    // get callback and state
    const {
        isLoading,
        data: gladiator,
        fetchError,
        fetchApi,
    } = useFetchCallback(
        `/api/gladiator/${id}`,
        "GET",
        { "Content-Type": "application/json" },
        null,
        null
    );

    // fetch gladiator
    useEffect(() => {
        fetchApi();
    }, [id]);

    // set states
    useEffect(() => {
        if (gladiator) {
            setName(gladiator.name);
            setHealth(gladiator.health);
            setStrength(gladiator.strength);
        }
    }, [gladiator, id]);

    if (isLoading || fetchError) {
        return <span>Loading...({fetchError})</span>;
    }

    return (
        <div>
            <h2>Edit {gladiator.name}</h2>
            <form>
                <label htmlFor="name" className="form-label">
                    Name
                </label>
                <input
                    type="text"
                    name="name"
                    className="form-control mb-3"
                    required
                    defaultValue={gladiator.name}
                    onChange={(e) => setName(e.target.value)}
                />
                <label htmlFor="health" className="form-label">
                    Health
                </label>
                <input
                    type="number"
                    name="Health"
                    className="form-control mb-3"
                    required
                    defaultValue={gladiator.health}
                    onChange={(e) => setHealth(e.target.value)}
                />
                <label htmlFor="strength" className="form-label">
                    Strength
                </label>
                <input
                    type="number"
                    name="strength"
                    className="form-control mb-3"
                    required
                    defaultValue={gladiator.strength}
                    onChange={(e) => setStrength(e.target.value)}
                />

                <EditButton
                    value="Update"
                    url={`/api/gladiator/${gladiator.id}`}
                    navigateTo={"/gladiator"}
                    body={{ name, health, strength }}
                />
            </form>
            <Link to="/gladiator" className="btn btn-secondary mb-3 col">
                Back
            </Link>
        </div>
    );
};

export default GladiatorEditPage;
