import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import SchoolEditPage from "./SchoolEditPage";

test("renders school edit page", () => {
    render(<SchoolEditPage />, { wrapper: BrowserRouter });
    const linkElement = screen.getByText(/Update|Loading.../i);
    expect(linkElement).toBeInTheDocument();
});