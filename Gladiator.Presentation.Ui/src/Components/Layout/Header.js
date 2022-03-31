import React from "react";
const Header = () => {
    return (
        <header>
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <div className="container-fluid">
                    <div className="collapse navbar-collapse" id="navbarNav">
                        <ul className="navbar-nav">
                            <li className="nav-item">
                                <a
                                    className="nav-link active"
                                    aria-current="page"
                                    href="/gladiator-create"
                                >
                                    Create Gladiator
                                </a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="/gladiator-edit">
                                    Edit Gladiator
                                </a>
                            </li>
                            <li className="nav-item">
                                <a
                                    className="nav-link"
                                    href="/gladiator-list"
                                >
                                    List of Gladiators
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </header>
    );
};
export default Header;
