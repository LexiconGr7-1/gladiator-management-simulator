import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import ArenaEditPage from "./ArenaEditPage";

test("renders arena edit page", () => {
    render(<ArenaEditPage />, { wrapper: BrowserRouter });
    const linkElement = screen.getByText(/Update|Loading.../i);
    expect(linkElement).toBeInTheDocument();
});