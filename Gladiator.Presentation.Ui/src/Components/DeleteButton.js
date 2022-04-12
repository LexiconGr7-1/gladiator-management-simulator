import { useNavigate } from "react-router-dom";

const DeleteButton = ({ value, url, navigateTo, className }) => {
    const navigate = useNavigate();
    const handleDelete = (e) => {
        e.preventDefault();

        fetch(url, { method: "DELETE" })
            .then(() => {
                navigate(navigateTo, { replace: true });
            })
            .catch((err) => console.log(err));
    };

    return (
        <button className={`btn btn-secondary ${className}`} onClick={handleDelete}>
            {value}
        </button>
    );
};

export default DeleteButton;
