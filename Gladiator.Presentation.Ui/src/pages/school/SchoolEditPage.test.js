import { render, screen } from "@testing-library/react";
import SchoolEditPage from "./SchoolEditPage";

test("renders school edit page", () => {
    render(<SchoolEditPage />);
    const linkElement = screen.getByText(/Update|Loading.../i);
    expect(linkElement).toBeInTheDocument();
});