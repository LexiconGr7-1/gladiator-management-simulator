import { Link } from "react-router-dom";
import React from "react";

const Header = () => {
    return (
        <header>
            <div clas>
                <Link to="/gladiator-create">Create Gladiator</Link>
                <Link to="/gladiator-edit">Edit Gladiator</Link>
                <Link to="/gladiator-list">Gladiator list</Link>
            </div>
        </header>
    );
};
export default Header;
