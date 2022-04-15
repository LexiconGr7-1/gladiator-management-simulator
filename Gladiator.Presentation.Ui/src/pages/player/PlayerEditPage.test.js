import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import PlayerEditPage from "./PlayerEditPage";

test("renders player edit page", () => {
    render(<PlayerEditPage />, { wrapper: BrowserRouter });
    const linkElement = screen.getByText(/Update|Loading.../i);
    expect(linkElement).toBeInTheDocument();
});