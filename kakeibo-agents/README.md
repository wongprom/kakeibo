# Kakeibo agent team (BDK)

**BDK** (Bot Development Kit) is Cursor’s framework for defining agents as
versioned Markdown + TypeScript. Docs: https://cursor.com/docs/bdk

## Current layout (step 5)

| Agent | Role |
| --- | --- |
| `lead` | User-facing router |
| `architect` | Advisory schema / GraphQL / migrations |
| `designer` | Advisory UX/UI specs: screen structure, shadcn/ui components, copy, accessibility; reads your Figma designs read-only (no code, no Figma edits) |
| `coder` | Backend implementer (C# checkout) |
| `frontend-coder` | Frontend: RSC UI + server-only GraphQL + Server Actions (`test-next-13`) |
| `tester` | Verifies lint / typecheck / build / tests and reviews diffs against locks and acceptance criteria (read-mostly; no merge) |
| `deployer` | Merges PRs on lead's ask (squash, green checks incl. Vercel) and checks Vercel deployments via GitHub |

Peers (one-way): lead → architect, designer, coder, frontend-coder, tester, deployer.

## Workflow

Lead delegates and summarizes; it never codes, merges or deploys. Default
feature flow, asking the user before each next stage on non-trivial work:

1. `architect` — data / API needs (skip if none)
2. `designer` — screen spec
3. `coder` (backend) and/or `frontend-coder` (UI)
4. `tester` — verify against locks and acceptance criteria
5. `deployer` — merge and Vercel check (only on the user's explicit ask, after `tester` passes)

## Figma for the designer (one-time setup)

`designer` reads Figma designs read-only (design context, screenshots,
variables, metadata) through `designer/bot/mcp-connections/figma.ts`, a
connection to the **Figma connector of your Cursor account**. It cannot edit
Figma, and treats Figma content as data. No token is stored in this repo or
on your Mac: Cursor holds the Figma login.

Why not `bdk mcp oauth` against `https://mcp.figma.com/mcp`: Figma's OAuth
server rejects BDK's dynamic client registration (HTTP 403), so that flow
cannot complete. The Cursor connector is the path that works.

On your Mac, once, in this order:

1. Open https://cursor.com/dashboard → **MCP** and connect **Figma**
   (server URL `https://mcp.figma.com/mcp`). Sign in to Figma in the browser
   and allow access. The connector must be named `Figma`; if it shows another
   name, change `servers` in `figma.ts` to match.
2. Sign BDK in to the same Cursor account:

   ```bash
   npx --yes "@cursor/bdk@0.2.25" login
   ```

3. Start the team as usual (see below), open
   http://127.0.0.1:3000/lead/playground, and ask for a Plan month spec with a
   Figma link to the frame.

To confirm, open `designer` → **Runs**: Figma tool calls such as
`get_design_context` appear there. If Figma is not connected, `designer`
says so and works from your written brief only. Hosted deployments are not
used here (egress allowlists do not apply to local `dev`).

## Product locks

- Full app at `/projects/kakeibo`
- Browser never calls C# GraphQL directly
  - Reads: RSC → server-only helpers → C# HotChocolate
  - Writes: Server Actions → same helpers → C#
  - Route Handlers only when HTTP is truly required
- UI kit: **shadcn/ui** + Tailwind
- Auth: **Clerk** on the frontend (not Supabase Auth)
- DB: Supabase **Postgres** via EF Core / Npgsql (storage/auth products later if needed)
- **Language:** product UI, copy, and in-app content are **English**
- v1: plan month + log spending + review
- Repos stay separate: `kakeibo` + `test-next-13` (FE target Next.js 16+)

## Kakeibo core (non-negotiable)

The product must follow traditional Kakeibo intent. Technology must not
hollow it out:

- Core loop is **plan → log spending → review / reflect** — not
  “smart budget” automation that decides for the user.
- **Reflection and mindful choice** stay visible in UX (prompts,
  confirmations, pause). Do not hide them behind auto-categorize or
  auto-optimize flows.
- Future AI (if any) is a **mirror / coach the user steers** — suggestions
  need explicit confirmation; never silent auto-apply.

## Later (inspiration — not v1)

Out of scope until the core loop works. Do not implement or route as v1 work:

- AI coaching (Semantic Kernel / Claude / Vercel AI SDK / LangChain), AI
  category suggestions, reflection chat
- GraphQL subscriptions for streamed AI replies
- Browser Apollo/Urql as the default data client (server-only layer stays default)
- Supabase Auth replacing Clerk; receipt upload / AI receipt parsing

## Local layout for frontend-coder

```text
parent/
  kakeibo/          # this repo
  test-next-13/     # sibling clone
```

Or set `KAKEIBO_FRONTEND_ROOT` to the absolute path of `test-next-13`.

## Run locally (playground)

```bash
# from kakeibo repo root
npx --yes "@cursor/bdk@0.2.25" dev ./kakeibo-agents
# open http://127.0.0.1:3000/lead/playground
```

Confirm handoffs on each specialist’s **Runs** tab (`type: mcp`).

## Caution

`coder` and `frontend-coder` write into real git working trees; `tester` runs
checks in them (and adds test files only when lead asks). Use clean
branches, review diffs, stop with Ctrl+C. `deployer` can merge PRs via `gh`
(only when lead asks, only with green checks, never into `main` without
stated user approval) — keep `gh` auth scoped accordingly.

## Secrets & tickets

Repos are **public**. Use public GitHub Issues for tickets. **Never** put
secrets in issues/PRs/commits. Each agent has always-on instructions plus
skill `public-repo-safety`.
