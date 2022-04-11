import { useNavigate } from "react-router-dom";

const DeleteButton = ({ value, url, navigateTo }) => {
    const navigate = useNavigate();
    const handleDelete = () => {
        
        fetch(url, { method: "DELETE" })
            .then(() => {
                navigate(
                    navigateTo,
                    { replace: true }
                )
            })
            .catch(err => console.log(err));
    }

    return <button className="btn btn-secondary" onClick={ handleDelete }>{ value }</button>
}

export default DeleteButton