const GladiatorCreatePage = () => {
    return (
        <div>
            <h2>Create gladiator [name]</h2>
            <form>
                <label htmlFor="name" className="form-label">
                    Name
                </label>
                <input type="text" name="name" className="form-control mb-3" />
                <label htmlFor="health" className="form-label">
                    Health
                </label>
                <input
                    type="number"
                    name="Health"
                    className="form-control mb-3"
                />
                <label htmlFor="strength" className="form-label">
                    Strength
                </label>
                <input
                    type="number"
                    name="strength"
                    className="form-control mb-3"
                />
                <button type="submit" className="btn btn-primary">
                    Create
                </button>
            </form>
        </div>
    );
};

export default GladiatorCreatePage;
