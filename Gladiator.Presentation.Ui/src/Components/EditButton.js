import { useNavigate } from "react-router-dom";

const EditButton = ({ value, url, navigateTo, body, className }) => {
    const navigate = useNavigate();

    const handleEdit = (e) => {
        e.preventDefault();

        fetch(url, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(body),
        })
            .then(() => {
                navigate(navigateTo, { replace: true });
            })
            .catch((err) => console.log(err));
    };

    return (
        <button className={`btn btn-secondary ${className}`} onClick={handleEdit}>
            {value}
        </button>
    );
};

export default EditButton;
