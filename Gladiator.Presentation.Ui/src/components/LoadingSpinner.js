const LoadingSpinner = ({ error }) => {
    const Style = {
        "position": "absolute",
        "left": "50%"}
    return (
        <div className="h-100 d-flex flex-column justify-content-center align-items-center" style={Style}>
            {!error && (
                <div className="spinner-border" role="status">
                    <span className="visually-hidden">Loading...</span>
                </div>
            )}
            {error && <div>{error}</div>}
        </div>
    );
};

export default LoadingSpinner;