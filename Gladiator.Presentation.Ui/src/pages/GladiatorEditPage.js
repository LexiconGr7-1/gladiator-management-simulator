import { useEffect } from "react";
import { useState } from "react";
import { useParams } from "react-router-dom";
import useFetchCallback from "../hooks/useFetchCallback";
import { Link } from "react-router-dom";
import EditButton from "../Components/EditButton";
//import useFetch from "../hooks/useFetch";

const GladiatorEditPage = () => {
    const { id } = useParams();
    //const { isLoading, data: gladiator, fetchError } = useFetch(`/api/gladiator/${id}`);
    //
    //if (isLoading || fetchError) {
    //    return <span>Loading...({fetchError})</span>;
    //}
    
    //const [name, setName] = useState("");
    //const [health, setHealth] = useState(0);
    //const [strength, setStrength] = useState(0);

    const [gladiator, setGladiator] = useState({});

    const { isLoading, data, fetchError, fetchApi } = useFetchCallback(
        `/api/gladiator/${id}`,
        "GET",
        { "Content-Type": "application/json" },
        null,
        null
    );

    //const updateStates = () => {
    //    setName(gladiator.name);
    //    setHealth(gladiator.health);
    //    setStrength(gladiator.strength);
    //};

    useEffect(() => {
        fetchApi();
    }, [id]);

    console.log(data);

    if (isLoading || fetchError) {
        return <span>Loading...({fetchError})</span>;
    }

    useEffect(() => {
        //updateStates();
        data && setGladiator( ...gladiator, { name: data.name, health: data.health, strength: data.strength });
    }, [gladiator]);

    console.log(gladiator);

    //useEffect(() => {
    //    
    //}, [gladiator]);

    //const handleSubmit = () => {
    //    const { isLoading: editIsLoading, fetchError: fetchEditError, fetchApi: fetchEdit } = useFetchCallback(
    //        `/api/gladiator/${id}`,
    //        "PUT",
    //        { "Content-Type": "application/json" },
    //        JSON.stringify({ name, health, strength }),
    //        "/gladiator"
    //    );
    //
    //    fetchEdit();
    //}

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
                    onChange={(e) => setGladiator(...gladiator, { name: e.target.value })}
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
                    onChange={(e) => setGladiator(...gladiator, { health: e.target.value })}
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
                    onChange={(e) => setGladiator(...gladiator, { strength: e.target.value })}
                />
                
                <EditButton
                    value="Update"
                    url={`/api/gladiator/${gladiator.id}`}
                    navigateTo="/gladiator"
                    body={ gladiator }
                />
            </form>
            <Link to="/gladiator" className="btn btn-secondary mb-3 col">
                Back
            </Link>
        </div>
    );
};

export default GladiatorEditPage;