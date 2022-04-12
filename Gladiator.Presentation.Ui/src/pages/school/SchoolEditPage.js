import { useParams } from "react-router-dom";
import useFetch from "../../hooks/useFetch";
import LoadingSpinner from "../../Components/LoadingSpinner";

const SchoolEditPage = () => {
    const { id } = useParams();
    const {
        isLoading,
        data: school,
        fetchError,
    } = useFetch(`/api/school/${id}`);

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
                    defaultValue={school.name}
                    className="form-control mb-3"
                />
                <button type="submit" className="btn btn-primary">
                    Update
                </button>
            </form>
        </div>
    );
};

export default SchoolEditPage;