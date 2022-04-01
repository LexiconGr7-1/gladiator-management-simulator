import { Link } from "react-router-dom";
import useFetch from "../components/useFetch";

const GladiatorListPage = () => {
    const { isLoading, data: gladiators, testData } = useFetch("https://jsonplaceholder.typicode.com/posts/1");

    if (isLoading) {
        return <span>Loading...</span>;
    }

    return (
        <div>
            {console.log(testData)}
            <h2>Gladiator List</h2>

            {gladiators &&
                gladiators.map((gladiator) => (
                    <div key={gladiator.id} className="mb-3">
                        <span className="col">{gladiator.name}</span>
                        <Link
                            to={"gladiator-details/" + gladiator.id}
                            className="btn btn-secondary mx-3 col"
                        >
                            Details
                        </Link>

                        <Link
                            to={"/gladiator-edit/" + gladiator.id}
                            className="btn btn-secondary mx-3 col"
                        >
                            Edit
                        </Link>
                        <Link
                            to={"/gladiator-delete/" + gladiator.id}
                            className="btn btn-secondary mx-3 col"
                        >
                            Delete
                        </Link>
                    </div>
                ))}

            {/* just output test data */}
            <div>
                <b>Test Data</b>
                {Object.keys(testData).map((key) => (
                    <div key={key}>
                        <label>{key}:</label>
                        <span>{testData[key]}</span>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default GladiatorListPage;
