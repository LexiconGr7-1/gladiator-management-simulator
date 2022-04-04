import { render, screen } from "@testing-library/react";
import GladiatorEditPage from "./GladiatorEditPage";

test("renders gladiator edit page", () => {
    render(<GladiatorEditPage />);
    const linkElement = screen.getByText(/Update|Loading.../i);
    expect(linkElement).toBeInTheDocument();
});