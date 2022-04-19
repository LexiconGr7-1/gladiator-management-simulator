const Checkbox = ({
    checkboxName,
    checkboxValue,
    handleCheckboxChange,
    checkboxChecked,
}) => {
    return (
        <>
            <input
                className="me-3"
                type="checkbox"
                name={checkboxName}
                value={checkboxValue}
                onChange={handleCheckboxChange}
                defaultChecked={checkboxChecked}
            />
        </>
    );
};

export default Checkbox;
