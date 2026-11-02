---
description: "Load for GitHub Issues/PRs, tickets, env vars, credentials, or any time secrets or public visibility might be involved."
---

# Public repo safety (Kakeibo team)

Repos `kakeibo` and `test-next-13` are **public**. There is **no private ticket board**.

## Never publish secrets

Do **not** put any of the following in Issues, PR bodies/comments, commit messages,
chat replies, eval fixtures, logs, or committed files:

- API keys, tokens, passwords, private keys
- `.env` contents, connection strings, Supabase service keys
- Clerk secret keys, webhook secrets
- Session cookies, auth headers with real credentials

## Where secrets belong

| Place | OK for secrets? |
| --- | --- |
| Local `.env` / `.env.local` (gitignored) | Yes |
| GitHub **Actions secrets** / hosting dashboards | Yes |
| GitHub **Issues** / public PRs | **No** |
| Agent playground chat | **No** (treat as exportable) |

## Tickets

Use public GitHub Issues for tasks. Describe work without credentials.
Refer to env **names** only (e.g. `KAKEIBO_GRAPHQL_URL`), never values.

If a task seems to require pasting a secret, **stop** and ask the human to
set it in env/hosting instead.
