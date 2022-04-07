import { useState } from "react";
import useFetchCallback from "../hooks/useFetchCallback";

const GladiatorCreatePage = () => {
    const [name, setName] = useState("");
    const [health, setHealth] = useState();
    const [strength, setStrength] = useState();

    const { isLoading, fetchError, fetchApi } = useFetchCallback(
        "/api/gladiator",
        "POST",
        { "Content-Type": "application/json" },
        JSON.stringify({ name, health, strength }),
        "/gladiator"
    );

    return (
        <div>
            <h2>Create new gladiator</h2>
            <form>
                <label htmlFor="name" className="form-label">
                    Name
                </label>
                <input
                    type="text"
                    name="name"
                    className="form-control mb-3"
                    required
                    value={name}
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
                    value={health}
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
                    value={strength}
                    onChange={(e) => setStrength(e.target.value)}
                />
                {!isLoading && (
                    <button
                        onClick={() => {
                            fetchApi();
                        }}
                        className="btn btn-primary"
                        type="button"
                    >
                        Add gladiator
                    </button>
                )}
                {isLoading && (
                    <button disabled className="btn btn-primary" type="submit">
                        Saving gladiator
                    </button>
                )}
                {fetchError && (
                    <div className="mt-2 text-danger">
                        Could not add gladiator. {fetchError}
                    </div>
                )}
            </form>
        </div>
    );
};

export default GladiatorCreatePage;
