import { BrowserRouter } from "react-router-dom";
import Layout from "./Components/Shared/Layout";
import Views from "./routes/Views";

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
