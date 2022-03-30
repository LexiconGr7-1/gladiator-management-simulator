import { Link } from "react-router-dom";
const GladiatorListPage = () => {
    return (
        <div>
            <h2>Gladiator List</h2>
            <div>
                <span className="col">Gladiator name </span>
                <Link
                    to="/gladiator-details"
                    className="btn btn-secondary m-3 col"
                >
                    Details
                </Link>
                <Link
                    to="/gladiator-edit"
                    className="btn btn-secondary m-3 col"
                >
                    Edit
                </Link>
                <Link
                    to="/gladiator-delete"
                    className="btn btn-secondary m-3 col"
                >
                    Delete
                </Link>
            </div>
        </div>
    );
};

export default GladiatorListPage;
