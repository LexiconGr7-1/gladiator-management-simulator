import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import ArenaCreatePage from "./ArenaCreatePage";

test("renders arena create page", () => {
    render(<ArenaCreatePage />, { wrapper: BrowserRouter });
    const linkElement = screen.getByText(/Create new Arena/i);
    expect(linkElement).toBeInTheDocument();
});