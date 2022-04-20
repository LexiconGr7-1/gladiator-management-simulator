import { Route, Routes } from "react-router-dom";
import LandingPage from "../pages/LandingPage";
import NotFound from "../pages/NotFound";
import PlayerListPage from "../pages/player/PlayerListPage";
import PlayerDetailsPage from "../pages/player/PlayerDetailsPage";
import PlayerCreatePage from "../pages/player/PlayerCreatePage";
import PlayerEditPage from "../pages/player/PlayerEditPage";
import GladiatorListPage from "../pages/gladiator/GladiatorListPage";
import GladiatorDetailsPage from "../pages/gladiator/GladiatorDetailsPage";
import GladiatorCreatePage from "../pages/gladiator/GladiatorCreatePage";
import GladiatorEditPage from "../pages/gladiator/GladiatorEditPage";
import SchoolListPage from "../pages/school/SchoolListPage";
import SchoolCreatePage from "../pages/school/SchoolCreatePage";
import SchoolDetailsPage from "../pages/school/SchoolDetailsPage";
import SchoolEditPage from "../pages/school/SchoolEditPage";
import ArenaListPage from "../pages/arena/ArenaListPage";
import ArenaDetailsPage from "../pages/arena/ArenaDetailsPage";
import ArenaEditPage from "../pages/arena/ArenaEditPage";
import ArenaCreatePage from "../pages/arena/ArenaCreatePage";

const Views = () => {
  return (
    <Routes>
      <Route exact path="/" element={<LandingPage />} />
      <Route exact path="/school" element={<SchoolListPage />} />
      <Route exact path="/school/create" element={<SchoolCreatePage />} />
      <Route exact path="/school/:id" element={<SchoolDetailsPage />} />
      <Route exact path="/school/edit/:id" element={<SchoolEditPage />} />
      <Route exact path="/gladiator/edit/:id" element={<GladiatorEditPage />} />
      <Route exact path="/gladiator/create" element={<GladiatorCreatePage />} />
      <Route exact path="/gladiator" element={<GladiatorListPage />} />
      <Route exact path="/gladiator/:id" element={<GladiatorDetailsPage />} />
      <Route exact path="/player" element={<PlayerListPage />} />
      <Route exact path="/player/:id" element={<PlayerDetailsPage />} />
      <Route exact path="/player/create" element={<PlayerCreatePage />} />
      <Route exact path="/player/edit/:id" element={<PlayerEditPage />} />
      <Route exact path="/arena" element={<ArenaListPage />} />
      <Route exact path="/arena/:id" element={<ArenaDetailsPage />} />
      <Route exact path="/arena/create" element={<ArenaCreatePage />} />
      <Route exact path="/arena/edit/:id" element={<ArenaEditPage />} />
      <Route index element={<LandingPage />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};

export default Views;
