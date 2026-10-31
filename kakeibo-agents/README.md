# Kakeibo agent team (BDK)

**BDK** (Bot Development Kit) is Cursor’s framework for defining agents as
versioned Markdown + TypeScript. Docs: https://cursor.com/docs/bdk

## Current layout (step 3)

| Agent | Role |
| --- | --- |
| `lead` | User-facing router |
| `architect` | Advisory schema / GraphQL / migrations |
| `coder` | Backend implementer (C# checkout) |
| `frontend-coder` | Frontend + Next.js BFF (`test-next-13`, `/projects/kakeibo`) |

Later: `designer`, `tester`, `deployer`.

Peers (one-way): lead → architect, coder, frontend-coder.

## Product locks

- Full app at `/projects/kakeibo`
- Browser → Next.js BFF → C# HotChocolate
- v1: plan month + log spending + review
- Repos stay separate: `kakeibo` + `test-next-13`

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

`coder` and `frontend-coder` write into real git working trees. Use clean
branches, review diffs, stop with Ctrl+C.
