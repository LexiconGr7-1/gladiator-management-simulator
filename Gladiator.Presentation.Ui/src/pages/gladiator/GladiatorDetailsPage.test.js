import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import GladiatorDetailsPage from "./GladiatorDetailsPage";

test("renders gladiator details page", () => {
    render(<GladiatorDetailsPage />, { wrapper: BrowserRouter });
    const linkElement = screen.getByText(/Back|Loading.../i);
    expect(linkElement).toBeInTheDocument();
});
