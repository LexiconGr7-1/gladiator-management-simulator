import { useState } from "react";
//import { useNavigate } from "react-router-dom";
import useFetch from "../hooks/useFetch";

const GladiatorCreatePage = () => {
    const [name, setName] = useState(null);
    const [health, setHealth] = useState(null);
    const [strength, setStrength] = useState(null);

    const [isLoading, setIsLoading] = useState(false);
    const [fetchError, setFetchError] = useState(false);

    //const navigate = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();

        const gladiator = { name, health, strength };
        const header = "{ 'Content-Type': 'application/json' }";
        setIsLoading(true);
        setFetchError(false);

        const { isLoading, data: gladiators, fetchError } = useFetch("/api/gladiator", "POST", JSON.stringify({ "Content-Type": "application/json" }), JSON.stringify(gladiator));

        //fetch("/api/gladiator", {
        //    method: "POST",
        //    headers: { "Content-Type": "application/json" },
        //    body: JSON.stringify(gladiator)
        //})
        //.then((res) => {
        //    console.log("new person created");
        //    if (!res.ok) {
        //        throw Error();
        //    }
        //})
        //.then(() => {
        //    navigate("/gladiator", { replace: true });
        //})
        //.catch((err) => {
        //    console.log(err.message);
        //    setIsLoading(false);
        //    setFetchError(true);
        //});
    };

    return (
        <div>
            <h2>Create new gladiator</h2>
            <form onSubmit={handleSubmit}>
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
                {/*<button className="btn btn-primary">Create</button>*/}
                {!isLoading && <button className="btn btn-primary" type="submit">Add gladiator</button>}
                {isLoading && (
                    <button disabled className="btn btn-primary" type="submit">
                        Saving gladiator
                    </button>
                )}
                {fetchError && (
                    <div className="mt-2 text-danger">Could not add person.</div>
                )}
            </form>
        </div>
    );
};

export default GladiatorCreatePage;
