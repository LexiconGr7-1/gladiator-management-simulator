const SchoolsInArena = ({ schools }) => {
    return schools.map((school) => {
        <div>{school.name}</div>;
    });
};

export default SchoolsInArena;
