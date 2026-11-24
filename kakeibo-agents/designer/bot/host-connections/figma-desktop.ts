import { defineConnection } from "@cursor/bdk/connections";

// Fallback: the Figma desktop app's local MCP server (Dev Mode). No token,
// nothing leaves the Mac. Needs the Figma desktop app running with its MCP
// server enabled; otherwise this connection simply errors and is skipped.
export default defineConnection({
  url: "http://127.0.0.1:3845/mcp",
});
