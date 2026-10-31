# Kakeibo agent team (BDK)

**BDK** (Bot Development Kit) is Cursor’s framework for defining agents as
versioned Markdown + TypeScript. You write instructions, tools, skills, and
evals; Cursor runs the model loop. Docs: https://cursor.com/docs/bdk

## Current layout (step 2)

| Agent | Role |
| --- | --- |
| `lead` | User-facing router. Delegates to peers. |
| `architect` | Advisory specialist: schema, EF relations, GraphQL shape, migrations. No code edits. |
| `coder` | Implements backend changes in the real C# checkout (`local.workspaceDir` = repo root). |

Later (not yet): `designer`, `tester`, `deployer` as peer agents.

Peers are one-way: **lead → architect**, **lead → coder**.

## Run locally (playground)

```bash
# from repo root — mounts all agents under one process
npx --yes "@cursor/bdk@0.2.25" dev ./kakeibo-agents

# playground URLs are printed; typical:
#   http://127.0.0.1:3000/          (home — lists agents)
#   http://127.0.0.1:3000/lead/playground
#   http://127.0.0.1:3000/architect/playground
#   http://127.0.0.1:3000/coder/playground
```

Talk to **lead**. Architecture → `architect`. Implementation → `coder`
(usually after a plan). Confirm handoffs on the specialist’s **Runs** tab
(`type: mcp`).

Model turns need a Cursor credential (`npx @cursor/bdk login` or
`CURSOR_API_KEY`).

## Per-agent checks

```bash
npx --yes "@cursor/bdk@0.2.25" validate --dir ./kakeibo-agents
npx --yes "@cursor/bdk@0.2.25" info --dir ./kakeibo-agents/coder --json
```

## Memory

Each agent journals turns via `bot/hooks/memory.ts` (`memoryHook`) into
`memory/journal.jsonl` under the project state directory. That is the BDK
memory path — not a hand-maintained markdown file.

## Caution (coder)

`coder` writes into your local git working tree. Use a clean branch, review
diffs, and stop `dev` with Ctrl+C when finished.
