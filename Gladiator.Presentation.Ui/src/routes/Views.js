import { Route, Routes } from "react-router-dom";
import LandingPage from "../pages/LandingPage";
import GladiatorListPage from "../pages/GladiatorListPage";
import NotFound from "../pages/NotFound";
import GladiatorCreatePage from "../pages/GladiatorCreatePage";
import GladiatorEditPage from "../pages/GladiatorEditPage";
import GladiatorDetailsPage from "../pages/GladiatorDetailsPage";
import ArenaListPage from "../pages/ArenaListPage";
import ArenaDetailsPage from "../pages/ArenaDetailsPage";

const Views = () => {
  return (
    <Routes>
      <Route exact path="/" element={<LandingPage />} />
      <Route exact path="/gladiator/edit/:id" element={<GladiatorEditPage />} />
      <Route exact path="/gladiator/create" element={<GladiatorCreatePage />} />
      <Route exact path="/gladiator" element={<GladiatorListPage />} />
      <Route exact path="/gladiator/:id" element={<GladiatorDetailsPage />} />
      <Route exact path="/arena" element={<ArenaListPage />} />
      <Route exact path="/arena-details" element={<ArenaDetailsPage />} />
      <Route index element={<LandingPage />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};

export default Views;
