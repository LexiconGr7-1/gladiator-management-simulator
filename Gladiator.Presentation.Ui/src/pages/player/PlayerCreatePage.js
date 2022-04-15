import { useState } from "react";
import useFetchCallback from "../../hooks/useFetchCallback";
import { Link } from "react-router-dom";

const PlayerCreatePage = () => {
    const [name, setName] = useState("");
    const [school, setSchool] = useState("");
    const [gladiator, setGladiator] = useState("");

    const { isLoading, fetchError, fetchApi } = useFetchCallback(
        "/api/player",
        "POST",
        { "Content-Type": "application/json" },
        JSON.stringify({ name, school, gladiator }),
        "/player"
    );

    return (
        <div>
            <h2>Create new player</h2>
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
                <label htmlFor="school" className="form-label">
                    School
                </label>
                <input
                    type="text"
                    name="school"
                    className="form-control mb-3"
                    required
                    value={school}
                    onChange={(e) => setSchool(e.target.value)}
                />
                <label htmlFor="gladiator" className="form-label">
                    Gladiator
                </label>
                <input
                    type="text"
                    name="gladiator"
                    className="form-control mb-3"
                    required
                    value={gladiator}
                    onChange={(e) => setGladiator(e.target.value)}
                />
                {!isLoading && (
                    <button
                        onClick={() => {
                            fetchApi();
                        }}
                        className="btn btn-primary mb-3"
                        type="button"
                    >
                        Add player
                    </button>
                )}
                {isLoading && (
                    <button
                        disabled
                        className="btn btn-primary mb-3"
                        type="submit"
                    >
                        Saving player
                    </button>
                )}
                {fetchError && (
                    <div className="mb-3 text-danger">
                        Could not add player. {fetchError}
                    </div>
                )}
            </form>
            <Link to="/player" className="btn btn-secondary mb-3 col">
                Back
            </Link>
        </div>
    );
};

export default PlayerCreatePage;
