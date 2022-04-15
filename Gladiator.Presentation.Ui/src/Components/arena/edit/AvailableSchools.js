import { useEffect } from "react";
import useFetchCallback from "../../../hooks/useFetchCallback";
import LoadingSpinner from "../../LoadingSpinner";

const AvailableSchools = () => {
    const {
        isLoading,
        data: schools,
        fetchError,
        fetchApi,
    } = useFetchCallback(
        `/api/player/school/notinarena`,
        "GET",
        { "Content-Type": "application/json" },
        null,
        null
    );

    useEffect(() => {
        fetchApi();
    }, []);

    if (isLoading || fetchError) {
        return <LoadingSpinner>({fetchError})</LoadingSpinner>;
    }

    return (
        <div className="my-3">
            <h5>Available schools</h5>
            {schools.map((school) => (
                <div key={school.id}>{school.name}</div>
            ))}
        </div>
    );
};

export default AvailableSchools;
