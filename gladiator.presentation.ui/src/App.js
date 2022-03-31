import { BrowserRouter } from "react-router-dom";
import Views from "./routes/Views";
import Layout from "./Components/Layout/Layout";

const App = () => {
    return (
        <Layout>
            <BrowserRouter>
                <Views />
            </BrowserRouter>
        </Layout>
    );
};

export default App;
