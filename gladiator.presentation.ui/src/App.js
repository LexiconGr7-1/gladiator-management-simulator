import { BrowserRouter } from "react-router-dom";
import Layout from "./Components/Shared/Layout";
import Views from "./routes/Views";

const App = () => {
    return (
        <BrowserRouter>
            <Layout>
                <Views />
            </Layout>
        </BrowserRouter>
    );
};

export default App;
