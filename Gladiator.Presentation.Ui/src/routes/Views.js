import { Route, Routes } from "react-router-dom";
import LandingPage from "../pages/LandingPage";
import GladiatorListPage from "../pages/GladiatorListPage";
import NotFound from "../pages/NotFound";
import GladiatorCreatePage from "../pages/GladiatorCreatePage";
import GladiatorEditPage from "../pages/GladiatorEditPage";
import GladiatorDetailsPage from "../pages/GladiatorDetailsPage";

const Views = () => {
  return (
    <Routes>
      <Route exact path="/" element={<LandingPage />} />
      <Route exact path="/gladiator-edit" element={<GladiatorEditPage />} />
      <Route exact path="/gladiator-create" element={<GladiatorCreatePage />} />
      <Route exact path="/gladiator-list" element={<GladiatorListPage />} />
      <Route exact path="/gladiator-details" element={<GladiatorDetailsPage />} />
      <Route index element={<LandingPage />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};

export default Views;
