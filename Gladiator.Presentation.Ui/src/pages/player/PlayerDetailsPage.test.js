import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import PlayerDetailsPage from "./PlayerDetailsPage";

test("renders player details page", () => {
    render(<PlayerDetailsPage />, { wrapper: BrowserRouter });
    const linkElement = screen.getByText(/Back|Loading.../i);
    expect(linkElement).toBeInTheDocument();
});