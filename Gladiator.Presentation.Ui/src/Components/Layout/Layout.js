import Header from "./Header";
import Footer from "./Footer";

function Layout(props) {
    return (
        <div className="h-100 row align-items-center">
            <Header />
            <main>{props.children}</main>
            <Footer />
        </div>
    );
}

export default Layout;
