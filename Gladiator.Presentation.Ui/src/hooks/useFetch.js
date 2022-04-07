import { useState, useEffect } from "react";

const useFetch = (url, method = "GET", header = null, body = null) => {
    const [isLoading, setIsLoading] = useState(true);
    const [data, setData] = useState(null);
    const [fetchError, setFetchError] = useState(null);

    useEffect(() => {
        const abortController = new AbortController();
        setIsLoading(true);

        const config = {
            signal: abortController.signal,
            method: method,
            header: header,
            body: body,
        };

        fetch(url, config)
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
    }, [url, method, header, body]);

        return { isLoading, data, fetchError };
};

export default useFetch;
