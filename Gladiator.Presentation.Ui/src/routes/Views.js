import { Route, Routes } from "react-router-dom";

import LandingPage from "../pages/LandingPage";
import NotFound from "../pages/NotFound";
import GladiatorCreatePage from "../pages/GladiatorCreatePage";
import GladiatorEditPage from "../pages/GladiatorEditPage";

const Views = () => {
  return (
    <Routes>
          <Route exact path="/" element={<LandingPage />} />
          <Route exact path="/gladiator-edit" element={<GladiatorEditPage />} />
      <Route index element={<LandingPage />} />
      <Route exact path="/gladiator-create" element={<GladiatorCreatePage />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};

export default Views;
