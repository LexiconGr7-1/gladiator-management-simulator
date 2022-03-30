import { Link } from "react-router-dom";
const GladiatorDetailsPage = () => {

    const Gladiator = { name: "Avatar", health: 50, strength: 20 }; // mock data to gladiator details

    return (
        <div>
            <h2>Gladiator {Gladiator.name} Details</h2>
            <div className="mb-3 row">
                <label className="col">Name</label>
                <span className="col">  {Gladiator.name} </span>
            </div>
            <div className="mb-3 row">
                <label className="col">Health</label>
                <span className="col">  {Gladiator.health} </span>
            </div>
            <div className="mb-3 row">
                <label className="col">Strength</label>
                <span className="col">  {Gladiator.strength} </span>
            </div>
            <Link
                to="/gladiator-list"
                className="btn btn-secondary m-3 col"
            >
                Back
            </Link>
        </div>

    );
};

export default GladiatorDetailsPage;