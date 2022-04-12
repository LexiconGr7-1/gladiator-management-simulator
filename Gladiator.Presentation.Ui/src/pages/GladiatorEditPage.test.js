import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import GladiatorEditPage from "./GladiatorEditPage";

test("renders gladiator edit page", () => {
    render(<GladiatorEditPage />, { wrapper: BrowserRouter });
    const linkElement = screen.getByText(/Update|Loading.../i);
    expect(linkElement).toBeInTheDocument();
});