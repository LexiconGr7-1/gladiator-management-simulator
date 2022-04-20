import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import PlayerCreatePage from "./PlayerCreatePage";

test("renders player create page", () => {
    render(<PlayerCreatePage />, { wrapper: BrowserRouter });
    const linkElement = screen.getByText(/Create new player/i);
    expect(linkElement).toBeInTheDocument();
});
