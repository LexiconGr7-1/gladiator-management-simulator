import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import GladiatorListPage from "./GladiatorListPage";

test("renders gladiator details page", () => {
    render(<GladiatorListPage />, { wrapper: BrowserRouter });
    const linkElement = screen.getByText(/Gladiator List/i);
    expect(linkElement).toBeInTheDocument();
});
