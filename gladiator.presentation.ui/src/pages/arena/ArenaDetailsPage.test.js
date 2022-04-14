import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import ArenaDetailsPage from "./ArenaDetailsPage";

test("renders arena details page", () => {
    render(<ArenaDetailsPage />, { wrapper: BrowserRouter });
    const linkElement = screen.getByText(/Back|Loading arena details.../i);
    expect(linkElement).toBeInTheDocument();
});