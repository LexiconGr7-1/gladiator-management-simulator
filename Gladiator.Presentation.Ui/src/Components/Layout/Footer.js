import React from "react";
import { Link } from "react-router-dom";

const Footer = () => {
    const FooterStyle = {
        "background-color": "#F8F9FA",
        "text-align": "center",
        "padding": "10px"
    }
    return (
        <footer className="footer-web footer-br fixed-bottom container" style={FooterStyle}>
            <div className="footer-content">
                <div className="footer-box">
                    <div className="footer-item">
                        <Link to="/Login">Sign in</Link>
                    </div>
                    <div className="footer-item">
                        <Link to="/signup">Sign up</Link>
                    </div>
                </div>
                <div className="footer-foot">
                    <p>&copy; Grupp-1 (Lexicon) - {new Date().getFullYear()}</p>
                </div>
            </div>
        </footer>
    );
};

export default Footer;
