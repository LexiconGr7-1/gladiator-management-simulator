import { Link } from "react-router-dom";
//import useFetch from "../hooks/useFetch";

const ArenaDetailsPage = () => {
    const Arenaname = "arena1";
    const Arenaschool = ["school1", "school2", "school3", "school4", "school5"];
    const ArenaGladiator = ["Gladiator1", "Gladiator2", "Gladiator3", "Gladiator4", "Gladiator5"];
    return (
        <div>
            <h2>Arena Details</h2>

            <div className="mb-3">
                <span className="col m-3">{Arenaname}</span>

                <span className="dropdown col m-3">
                    <button className="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
                        Arena school
                    </button>
                    <ul className="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                        <li className="dropdown-item"> {Arenaschool[0]}</li>
                        <li className="dropdown-item"> {Arenaschool[1]}</li>
                        <li className="dropdown-item"> {Arenaschool[2]}</li>
                    </ul>
                </span>

                <span className="dropdown col m-3">
                    <button className="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
                        Arena gladiator
                    </button>
                    <ul className="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                        <li><a className="dropdown-item" >{ArenaGladiator[0]}</a></li>
                        <li><a className="dropdown-item" >{ArenaGladiator[1]}</a></li>
                        <li><a className="dropdown-item" >{ArenaGladiator[2]}</a></li>
                    </ul>
                </span>


            </div>
            <Link
                to="/arena"
                className="btn btn-secondary mx-3 col"
            >
                Back to Arena
            </Link>
        </div>
    );
};

export default ArenaDetailsPage;
