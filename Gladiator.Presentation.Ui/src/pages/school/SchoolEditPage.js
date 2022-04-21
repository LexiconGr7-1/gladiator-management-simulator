import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import useFetchCallback from "../../hooks/useFetchCallback";
import LoadingSpinner from "../../Components/LoadingSpinner";
import EditButton from "../../Components/EditButton";

const SchoolEditPage = () => {
    const { id } = useParams();
    const [name, setName] = useState("");

    // get callback and state
    const {
        isLoading,
        data: school,
        fetchError,
        fetchApi,
    } = useFetchCallback(
        `/api/school/${id}`,
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
        if (school) {
            setName(school.name);
        }
    }, [school, id]);

    if (isLoading || fetchError) {
        return <LoadingSpinner>({fetchError})</LoadingSpinner>;
    }

    return (
        <div>
            <h2>Edit {school.name}</h2>
            <form>
                <label htmlFor="name" className="form-label">
                    Name
                </label>
                <input
                    type="text"
                    name="name"
                    className="form-control mb-3"
                    required
                    defaultValue={school.name}
                    onChange={(e) => setName(e.target.value)}
                />
                <EditButton
                    value="Update"
                    url={`/api/school/${school.id}`}
                    navigateTo={"/school"}
                    body={{ name }}
                    className="mb-3 col"
                />
            </form>
            <Link to="/school" className="btn btn-secondary mb-3 col">
                Back
            </Link>
        </div>
    );
};

export default SchoolEditPage;
