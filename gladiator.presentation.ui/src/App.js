import { Route, Routes } from "react-router-dom";

import LandingPage from "./pages/LandingPage";

const App = () => {
  <div>
    <Routes>
      <Route exact path="/" element={<LandingPage />} />
    </Routes>
  </div>;
};

export default App;
