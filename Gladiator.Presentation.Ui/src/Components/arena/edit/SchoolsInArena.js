//import { useState } from "react";

import Checkbox from "../../Checkbox";

const SchoolsInArena = ({ schools }) => {
    const handleCheckboxChange = (e) => {
        var obj = { schoolId: e.target.value, checkedValue: e.target.checked };
        console.log(obj);
    };

    return (
        <div className="my-3">
            <h5>Schools in arena</h5>
            {schools &&
                schools.map((school) => (
                    <div key={school.id}>
                        <Checkbox
                            checkboxName="schools"
                            checkboxValue={school.id}
                            handleCheckboxChange={handleCheckboxChange}
                            checkboxChecked={true}
                        />
                        {school.name}
                    </div>
                ))}
            <div></div>
        </div>
    );
};

export default SchoolsInArena;
