import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import ArenaListPage from "./ArenaListPage";

test("renders player list page", () => {
    render(<ArenaListPage />, { wrapper: BrowserRouter });
    const linkElement = screen.getByText(/Arena List|Loading arena list...\.\.\./i);
    expect(linkElement).toBeInTheDocument();
});