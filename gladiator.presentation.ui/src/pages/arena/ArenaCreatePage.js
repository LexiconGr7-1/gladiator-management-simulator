const ArenaCreatePage = () => {
    return (

        <div>
            <h2>Create new Arena</h2>
            <form>
                <label htmlFor="name" className="form-label">Name</label>
                <input type="text" name="name" className="form-control mb-3" />
                <button type="submit" className="btn btn-primary">Create Arena</button>
            </form>
        </div>
    );
}

export default ArenaCreatePage;