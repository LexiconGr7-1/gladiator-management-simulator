import { useEffect } from "react";
import { useState, useCallback } from "react";
import { useNavigate } from "react-router-dom";

const useFetchCallback = (
    url,
    method = "GET",
    headers = null,
    body = null,
    navigateTo = null
) => {
    const [isLoading, setIsLoading] = useState(true);
    const [data, setData] = useState(null);
    const [fetchError, setFetchError] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        if (method != "GET") setIsLoading(false);
    }, []);

    const fetchApi = useCallback(() => {
        const abortController = new AbortController();
        setIsLoading(true);

        const config = {
            signal: abortController.signal,
            method: method,
            headers: headers,
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

                if (navigateTo !== null) {
                    navigate(navigateTo, { replace: true });
                }
            })
            .catch((err) => {
                console.log(err);
                if (err.name === "AbortError") {
                    console.log("fetch aborted");
                } else {
                    setIsLoading(false);
                    setFetchError(err.message);
                }
            });
        return () => abortController.abort();
    }, [url, method, headers, body, navigateTo]);
    
    return { isLoading, data, fetchError, fetchApi };
};

export default useFetchCallback;
