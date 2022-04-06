import { Route, Routes } from "react-router-dom";
import LandingPage from "../pages/LandingPage";
import GladiatorListPage from "../pages/GladiatorListPage";
import NotFound from "../pages/NotFound";
import GladiatorCreatePage from "../pages/GladiatorCreatePage";
import GladiatorEditPage from "../pages/GladiatorEditPage";
import GladiatorDetailsPage from "../pages/GladiatorDetailsPage";
import SchoolListPage from "../pages/school/SchoolListPage";
import SchoolCreatePage from "../pages/school/SchoolCreatePage";
import SchoolDetailsPage from "../pages/school/SchoolDetailsPage";
import SchoolEditPage from "../pages/school/SchoolEditPage";

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
      <Route index element={<LandingPage />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};

export default Views;
