import { render, screen } from "@testing-library/react";
import NotFound from "./NotFound";

test("renders not found page", () => {
  render(<NotFound />);
  const linkElement = screen.getByText(/Page not found/i);
  expect(linkElement).toBeInTheDocument();
});
