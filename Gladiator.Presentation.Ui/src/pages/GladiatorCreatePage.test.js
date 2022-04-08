import { render, screen } from "@testing-library/react";
import GladiatorCreatePage from "./GladiatorCreatePage";

test("renders gladiator create page", () => {
    render(<GladiatorCreatePage />);
    const linkElement = screen.getByText(/Create new gladiator/i);
    expect(linkElement).toBeInTheDocument();
});