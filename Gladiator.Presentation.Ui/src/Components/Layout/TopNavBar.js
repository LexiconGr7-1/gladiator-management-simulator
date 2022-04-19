import { Link } from "react-router-dom";

const TopNavBar = () => {
    const LogoStyle = {
        "height": "100px",
        "width": "89px"
    }
    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container-fluid">
                <Link to="/"> <img src="images/logogladiator.png" alt="Gladiator Logo" style={LogoStyle} /></Link>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav">
                        <li className="nav-item">
                            <Link className="nav-link" to="/gladiator">Gladiator</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/player">Player</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/arena">Arena</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/school">School</Link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    );
}

export default TopNavBar;