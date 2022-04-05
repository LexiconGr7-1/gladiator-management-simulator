import { useParams } from "react-router-dom";
import useFetch from "../hooks/useFetch";

const GladiatorEditPage = () => {
    const { id } = useParams();
    const { isLoading, data: gladiator, fetchError } = useFetch(`/api/gladiator/${id}`);

    if (isLoading || fetchError) {
        return <span>Loading...({fetchError})</span>;
    }

    return (
        <div>
            <h2>Edit {gladiator.name}</h2>
            <form>
                <label htmlFor="name" className="form-label">Name</label>
                <input type="text" name="name" defaultValue={gladiator.name} className="form-control mb-3"/>
                <label htmlFor="health" className="form-label">Health</label>
                <input type="number" name="Health" defaultValue={gladiator.health} className="form-control mb-3"/>
                <label htmlFor="strength" className="form-label">Strength</label>
                <input type="number" name="strength" defaultValue={gladiator.strength} className="form-control mb-3"/>
                <button type="submit" className="btn btn-primary">Update</button>
            </form>
        </div>
    );
};

export default GladiatorEditPage;