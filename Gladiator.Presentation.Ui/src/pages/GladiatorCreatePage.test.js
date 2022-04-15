import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import GladiatorCreatePage from "./GladiatorCreatePage";

test("renders gladiator create page", () => {
    render(<GladiatorCreatePage />, { wrapper: BrowserRouter });
    const linkElement = screen.getByText(/Create new gladiator/i);
    expect(linkElement).toBeInTheDocument();
});