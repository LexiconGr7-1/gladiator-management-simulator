import { render, screen } from "@testing-library/react";
import SchoolCreatePage from "./SchoolCreatePage";

test("renders school create page", () => {
    render(<SchoolCreatePage />);
    const linkElement = screen.getByText(/Create new school/i);
    expect(linkElement).toBeInTheDocument();
});