import { Route, Routes } from "react-router-dom";

import LandingPage from "../pages/LandingPage";
import GladiatorListPage from "../pages/GladiatorListPage";
import NotFound from "../pages/NotFound";

const Views = () => {
  return (
    <Routes>
          <Route exact path="/" element={<LandingPage />} />'         
          <Route index element={<LandingPage />} />
          <Route exact path="/gladiator-list" element={<GladiatorListPage />} />
          <Route path="*" element={<NotFound />} />
    </Routes>
  );
};

export default Views;
