import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import PlayerListPage from "./PlayerListPage";

test("renders player list page", () => {
    render(<PlayerListPage />, { wrapper: BrowserRouter });
    const linkElement = screen.getByText(/Player List|Loading\.\.\./i);
    expect(linkElement).toBeInTheDocument();
});