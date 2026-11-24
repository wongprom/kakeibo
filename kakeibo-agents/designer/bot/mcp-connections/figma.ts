import { defineConnection } from "@cursor/bdk/connections";

// Read-only Figma access through the Cursor account's Figma connector.
// Tokens stay on the Cursor backend; nothing is stored in this repo or on
// the serve host. Authorize once in Cursor dashboard -> MCP (see README).
// `{ url: "https://mcp.figma.com/mcp", oauth: true }` is not used: Figma's
// OAuth server answers 403 to BDK's dynamic client registration.
export default defineConnection({
  cursorAccount: true,
  servers: ["Figma"],
  advertiseTools: true,
  optional: true,
  tools: [
    "whoami",
    "create_session",
    "get_design_context",
    "get_screenshot",
    "get_metadata",
    "get_variable_defs",
    "get_code_connect_map",
    "get_libraries",
    "search_design_system",
    "get_comments",
    "get_figjam",
  ],
});
