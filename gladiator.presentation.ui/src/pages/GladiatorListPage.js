import { useState, useEffect } from "react";

import { Link } from "react-router-dom";

const GladiatorListPage = () => {
    const [isLoading, setIsLoading] = useState(true);
    const [gladiators, setGladiators] = useState([]);
    const [testData, setTestData] = useState(null);

    useEffect(() => {
        setIsLoading(true);
        fetch("https://jsonplaceholder.typicode.com/posts/1")
            .then((res) => {
                return res.json();
            })
            .then((data) => {
                setTestData(data);

                // mock data for real fetch
                setGladiators([
                    { id: 1, name: "Gladiator 1" },
                    { id: 2, name: "Gladiator 2" },
                    { id: 3, name: "Gladiator 3" },
                    { id: 4, name: "Gladiator 4" },
                ]);
                setIsLoading(false);
            })
            .catch((err) => {
                console.log("fetch error: " + err);
                setIsLoading(false);
            });
    }, []);

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
