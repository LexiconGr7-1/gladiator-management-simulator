import { useState, useEffect } from 'react';
import { Link } from "react-router-dom";
const GladiatorListPage = () => {
    const [gladiators, setGladiators] = useState([]);

    useEffect(() => {
        //fetch('https://api.github.com/users/treox')
        //    .then(res => {
        //        return res.json();
        //    })
        //    .then(data => {
        //        console.log(data);
        //        setGladiators(data);
        //    })
        //    .catch(err => {
        //        console.log(err);
        //    });

            setGladiators([{ id:1, name: "Gladiator1" }, { id:2, name: "Gladiator2" }, { id:3, name: "Gladiator3" }, { id:4, name: "Gladiator4" }]);
    }, []);

    console.log(gladiators.map((g) => {return g.name}));

    return (
        <div>
            <h2>Gladiator List</h2>
            <div>
                {(gladiators.map((gladiator) => (
                <div key={gladiator.id}>
                    <span className="col">{gladiator.name}</span>
                <Link
                    to="/gladiator-details/" + {gladiator.id}
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
                )))}
            </div>
        </div>
    );
};

export default GladiatorListPage;
