import { render, screen } from "@testing-library/react";
import LandingPage from "./LandingPage";

test("renders landing page", () => {
    render(<LandingPage />);
    const linkElement = screen.getByText(/Landing Page/i);
    expect(linkElement).toBeInTheDocument();
});
