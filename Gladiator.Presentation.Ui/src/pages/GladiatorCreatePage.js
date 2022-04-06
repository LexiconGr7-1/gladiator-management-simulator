import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
//import useFetch from "../hooks/useFetch";

const GladiatorCreatePage = () => {
    const [name, setName] = useState(null);
    const [health, setHealth] = useState(null);
    const [strength, setStrength] = useState(null);
    const navigate = useNavigate();

    // const handleSubmit = (e) => {
    //     e.preventDefault();
    //     const gladiator = { name, health, strength };

    //     console.log(gladiator);

    //     useFetch(
    //         "/api/gladiator",
    //         "POST",
    //         { "Content-Type": "application/json" },
    //         JSON.stringify(gladiator)
    //     );

    //     //navigate("/gladiator", { replace: true });
    // };

    //}

    const handleSubmit = (e) => {
        e.preventDefault();

        const gladiator = { name, health, strength };

        fetch("/api/gladiator", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(gladiator),
        }).then(() => {
            navigate("/gladiator", { replace: true });
        });
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
                <button className="btn btn-primary">Create</button>
            </form>
        </div>
    );
};

export default GladiatorCreatePage;
