import { useState } from "react";
import useFetchCallback from "../../hooks/useFetchCallback";
import { Link } from "react-router-dom";

const SchoolCreatePage = () => {
    const [name, setName] = useState("");

    const { isLoading, fetchError, fetchApi } = useFetchCallback(
        "/api/school",
        "POST",
        { "Content-Type": "application/json" },
        JSON.stringify({ name }),
        "/school"
    );

    return (
        <div>
            <h2>Create new school</h2>
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
                        Add school
                    </button>
                )}
                {isLoading && (
                    <button
                        disabled
                        className="btn btn-primary mb-3"
                        type="submit"
                    >
                        Saving school
                    </button>
                )}
                {fetchError && (
                    <div className="mb-3 text-danger">
                        Could not add school. {fetchError}
                    </div>
                )}
            </form>
            <Link to="/school" className="btn btn-secondary mb-3 col">
                Back
            </Link>
        </div>
    );
};

export default SchoolCreatePage;
