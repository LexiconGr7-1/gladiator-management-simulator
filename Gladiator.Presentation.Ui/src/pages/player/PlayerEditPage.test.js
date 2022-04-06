import { render, screen } from "@testing-library/react";
import PlayerEditPage from "./PlayerEditPage";

test("renders player edit page", () => {
    render(<PlayerEditPage />);
    const linkElement = screen.getByText(/Update|Loading.../i);
    expect(linkElement).toBeInTheDocument();
});