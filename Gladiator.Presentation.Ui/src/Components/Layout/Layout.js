import Header from "./Header";
import Footer from "./Footer";

function Layout(props) {
    const MB = {
        marginBottom: "8rem",
    };
    return (
        <div className="container">
            <Header />
            <main style={MB}>{props.children}</main>
            <Footer />
        </div>
    );
}

export default Layout;
