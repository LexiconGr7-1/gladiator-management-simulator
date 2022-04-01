import { useState, useEffect } from 'react';

const useFetch = (url) => {
    const [isLoading, setIsLoading] = useState(true);
    const [data, setData] = useState([]);
    const [testData, setTestData] = useState(null);

    useEffect(() => {
        setIsLoading(true);
        fetch(url)
            .then((res) => {
                return res.json();
            })
            .then((data) => {
                setTestData(data);

                // mock data for real fetch
                setData([
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
    }, [url]);

    return { isLoading, data, testData };
}

export default useFetch;
