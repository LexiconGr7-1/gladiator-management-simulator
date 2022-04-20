import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import SchoolCreatePage from "./SchoolCreatePage";

test("renders school create page", () => {
    render(<SchoolCreatePage />, { wrapper: BrowserRouter });
    const linkElement = screen.getByText(/Create new school/i);
    expect(linkElement).toBeInTheDocument();
});