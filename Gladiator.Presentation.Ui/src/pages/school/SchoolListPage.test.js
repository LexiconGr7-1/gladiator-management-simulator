import { render, screen } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import SchoolListPage from "./SchoolListPage";

test("renders school list page", () => {
    render(<SchoolListPage />, { wrapper: BrowserRouter });
    const linkElement = screen.getByText(/School List|Loading\.\.\./i);
    expect(linkElement).toBeInTheDocument();
});