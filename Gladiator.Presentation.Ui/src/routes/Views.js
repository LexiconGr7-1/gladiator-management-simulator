import { Route, Routes } from "react-router-dom";
import LandingPage from "../pages/LandingPage";
import NotFound from "../pages/NotFound";
import PlayerListPage from "../pages/player/PlayerListPage";
import PlayerDetailsPage from "../pages/player/PlayerDetailsPage";
import PlayerCreatePage from "../pages/player/PlayerCreatePage";
import PlayerEditPage from "../pages/player/PlayerEditPage";
import GladiatorListPage from "../pages/GladiatorListPage";
import GladiatorDetailsPage from "../pages/GladiatorDetailsPage";
import GladiatorCreatePage from "../pages/GladiatorCreatePage";
import GladiatorEditPage from "../pages/GladiatorEditPage";

const Views = () => {
    return (
        <Routes>
            <Route exact path="/" element={<LandingPage />} />
            <Route exact path="/player" element={<PlayerListPage />} />
            <Route exact path="/player/:id" element={<PlayerDetailsPage />} />
            <Route exact path="/player/create" element={<PlayerCreatePage />} />
            <Route exact path="/player/edit/:id" element={<PlayerEditPage />} />
            <Route exact path="/gladiator" element={<GladiatorListPage />} />
            <Route
                exact
                path="/gladiator/:id"
                element={<GladiatorDetailsPage />}
            />
            <Route
                exact
                path="/gladiator/create"
                element={<GladiatorCreatePage />}
            />
            <Route
                exact
                path="/gladiator/edit/:id"
                element={<GladiatorEditPage />}
            />
            <Route index element={<LandingPage />} />
            <Route path="*" element={<NotFound />} />
        </Routes>
    );
};

export default Views;
