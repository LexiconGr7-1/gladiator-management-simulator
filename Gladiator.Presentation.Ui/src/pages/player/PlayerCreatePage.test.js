import { render, screen } from "@testing-library/react";
import PlayerCreatePage from "./PlayerCreatePage";

test("renders player create page", () => {
    render(<PlayerCreatePage />);
    const linkElement = screen.getByText(/Create new player/i);
    expect(linkElement).toBeInTheDocument();
});