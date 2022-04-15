const SchoolsInArena = ({ schools }) => {
    return (
        <div className="my-3">
            <h5>Schools in arena</h5>
            {schools.map((school) => (
                <div key={school.id}>{school.name}</div>
            ))}
        </div>
    );
};

export default SchoolsInArena;
