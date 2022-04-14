import { useState } from "react";
import useFetchCallback from "../../hooks/useFetchCallback";
import { Link } from "react-router-dom";

const ArenaCreatePage = () => {
    const [name, setName] = useState("");
    //const [school, setSchool] = useState("");
    //const [gladiator, setGladiator] = useState("");

    const { isLoading, fetchError, fetchApi } = useFetchCallback(
        "/api/arena",
        "POST",
        { "Content-Type": "application/json" },
        JSON.stringify({ name }),
        "/arena"
    );

    return (
        <div>
            <h2>Create new Arena</h2>
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
                {!isLoading && (
                    <button
                        onClick={() => {
                            fetchApi();
                        }}
                        className="btn btn-primary mb-3"
                        type="button"
                    >
                        Add arena
                    </button>
                )}
                {isLoading && (
                    <button
                        disabled
                        className="btn btn-primary mb-3"
                        type="submit"
                    >
                        Saving arena
                    </button>
                )}
                {fetchError && (
                    <div className="mb-3 text-danger">
                        Could not add arena. {fetchError}
                    </div>
                )}
            </form>
            <Link to="/arena" className="btn btn-secondary mb-3 col">
                Back
            </Link>
        </div>
    );
};

export default ArenaCreatePage;
