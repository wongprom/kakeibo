import { defineConnection } from "@cursor/bdk/connections";

export default defineConnection({
  agent: "designer",
  description:
    "Ask the designer for a UX/UI spec of a Kakeibo screen: layout, shadcn/ui components, states, English copy, accessibility, and where reflection stays visible. Can read Figma designs read-only when given a link. Advisory only; it writes no code and edits nothing in Figma.",
});
