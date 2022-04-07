import { Link } from "react-router-dom";
//import useFetch from "../hooks/useFetch";

const ArenaListPage = () => {
    var ArenaList = "arena1";
    return (
        <div>
            <h2>Arena List</h2>


            <div className="mb-3">
                <span className="col">{ArenaList}</span>
                <Link
                    to="/arena-details"
                    className="btn btn-secondary mx-3 col"
                >
                    Details
                </Link>

                <Link
                    to="/arena-edit"
                    className="btn btn-secondary mx-3 col"
                >
                    Edit
                </Link>

                <Link
                    to="/arenadelete"
                    className="btn btn-secondary mx-3 col"
                >
                    Delete
                </Link>

            </div>

        </div>
    );
};

export default ArenaListPage;
