import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import SchoolDetailsPage from "./SchoolDetailsPage";

test("renders school details page", () => {
    render(<SchoolDetailsPage />, { wrapper: BrowserRouter });
    const linkElement = screen.getByText(/Back|Loading.../i);
    expect(linkElement).toBeInTheDocument();
});