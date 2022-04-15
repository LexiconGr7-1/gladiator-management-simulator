import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
//import AvailableSchools from "../../Components/arena/edit/AvailableSchools";
import SchoolsInArena from "../../Components/arena/edit/SchoolsInArena";
import LoadingSpinner from "../../Components/LoadingSpinner";
import useFetchCallback from "../../hooks/useFetchCallback";
import EditButton from "../../Components/EditButton";

const ArenaEditPage = () => {
    const { id } = useParams();
    const [name, setName] = useState("");
    const [arenaSchools, setArenaSchools] = useState([]);

    // get callback and state
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

    // fetch gladiator
    useEffect(() => {
        fetchApi();
    }, [id]);

    // set states
    useEffect(() => {
        if (arena) {
            setName(arena.name);
            setArenaSchools(arena.schools);
        }
    }, [arena, id]);

    if (isLoading || fetchError) {
        return <LoadingSpinner>({fetchError})</LoadingSpinner>;
    }

    return (
        <div>
            <h2>Edit {arena.name}</h2>
            <form>
                <label htmlFor="name" className="form-label">
                    Name
                </label>
                <input
                    type="text"
                    name="name"
                    className="form-control mb-3"
                    required
                    defaultValue={arena.name}
                    onChange={(e) => setName(e.target.value)}
                />
                <SchoolsInArena schools={arenaSchools} />
                <EditButton
                    value="Update"
                    url={`/api/arena/${arena.id}`}
                    navigateTo={"/player"}
                    body={{ name }}
                    className="mb-3 col"
                />
            </form>
            <Link to="/arena" className="btn btn-secondary mb-3 col">
                Back
            </Link>
        </div>
    );
};

export default ArenaEditPage;
