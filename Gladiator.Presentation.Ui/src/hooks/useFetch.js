import { useState, useEffect } from "react";

const useFetch = (url) => {
    const [isLoading, setIsLoading] = useState(true);
    const [data, setData] = useState(null);
    const [fetchError, setFetchError] = useState(null);

    useEffect(() => {
        const abortController = new AbortController();
        setIsLoading(true);

        fetch(url, { signal: abortController.signal })
            .then((res) => {
                if (!res.ok) {
                    throw Error("Could not fetch data from that resource");
                }
                return res.json();
            })
            .then((data) => {
                setData(data);
                setIsLoading(false);
                setFetchError(null);
            })
            .catch((err) => {
                if (err.name === "AbortError") {
                    console.log("fetch aborted");
                } else {
                    setIsLoading(false);
                    setFetchError(err.message);
                }
            });
        return () => abortController.abort();
    }, [url]);

    return { isLoading, data, fetchError };
}

export default useFetch;
