# Kakeibo agent team (BDK)

**BDK** (Bot Development Kit) is Cursor’s framework for defining agents as
versioned Markdown + TypeScript. You write instructions, tools, skills, and
evals; Cursor runs the model loop. Docs: https://cursor.com/docs/bdk

## Step 1 layout

| Agent | Role |
| --- | --- |
| `lead` | User-facing router. Delegates architecture work to `architect`. |
| `architect` | Advisory specialist: schema, EF relations, GraphQL shape, migrations. No code edits. |

Later (not yet): `coder`, `designer`, `tester`, `deployer` as peer agents.

## Run locally (playground)

```bash
# from repo root — mounts both agents under one process
npx --yes "@cursor/bdk@0.2.25" dev ./kakeibo-agents

# playground URLs are printed; typical:
#   http://127.0.0.1:3000/lead/playground
#   http://127.0.0.1:3000/architect/playground
```

Talk to **lead**. Architecture questions should be delegated to **architect**
via the peer MCP connection (`ask` / `check`).

Model turns need a Cursor credential (`npx @cursor/bdk login` or
`CURSOR_API_KEY`).

## Per-agent checks

```bash
npx --yes "@cursor/bdk@0.2.25" validate --dir ./kakeibo-agents/architect
npx --yes "@cursor/bdk@0.2.25" validate --dir ./kakeibo-agents/lead
npx --yes "@cursor/bdk@0.2.25" info --dir ./kakeibo-agents/architect --json
npx --yes "@cursor/bdk@0.2.25" info --dir ./kakeibo-agents/lead --json
```

## Memory

Each agent journals turns via `bot/hooks/memory.ts` (`memoryHook`) into
`memory/journal.jsonl` under the project state directory. That is the BDK
memory path — not a hand-maintained markdown file.
