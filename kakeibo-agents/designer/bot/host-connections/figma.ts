import { defineConnection } from "@cursor/bdk/connections";

// Figma through the Cursor account (the Figma plugin's MCP). Host-only: the
// model never sees this connection or the account's other connectors. It only
// reaches Figma through the read-only tools in bot/tools/ (see bot/lib/figma.ts).
// No `servers` filter on purpose: the backend lists connectors by an internal
// identifier (e.g. `user-<name>`), not the dashboard name, so a name filter can
// silently match nothing. The wrapper picks the Figma tools by name instead.
export default defineConnection({
  cursorAccount: true,
});
