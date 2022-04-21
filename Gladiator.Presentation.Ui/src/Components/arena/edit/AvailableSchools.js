import { useEffect } from "react";
import useFetchCallback from "../../../hooks/useFetchCallback";
import Checkbox from "../../Checkbox";
import LoadingSpinner from "../../LoadingSpinner";

const AvailableSchools = () => {
    const {
        isLoading,
        data: schools,
        fetchError,
        fetchApi,
    } = useFetchCallback(
        `/api/player/school/notinarena`,
        "GET",
        { "Content-Type": "application/json" },
        null,
        null
    );

    useEffect(() => {
        fetchApi();
    }, []);

    const handleCheckboxChange = (e) => {
        var obj = { schoolId: e.target.value, checkedValue: e.target.checked };
        console.log(obj);
    };

    if (isLoading || fetchError) {
        return <LoadingSpinner>({fetchError})</LoadingSpinner>;
    }

    return (
        <div className="my-3">
            <h5>Available schools</h5>
            {schools &&
                schools.map((school) => (
                    <div key={school.id}>
                        <Checkbox
                            checkboxName="schools"
                            checkboxValue={school.id}
                            handleCheckboxChange={handleCheckboxChange}
                            checkboxChecked={false}
                        />
                        {school.name}
                    </div>
                ))}
        </div>
    );
};

export default AvailableSchools;
