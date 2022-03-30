import { render, screen } from "@testing-library/react";
import GladiatorDetailsPage from "./GladiatorDetailsPage";

test("renders gladiator details page", () => {
    render(<GladiatorDetailsPage />);
    const linkElement = screen.getByText(/Gladiator/i);
    expect(linkElement).toBeInTheDocument();
});