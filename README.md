
# Run Application
## Launch profiles

| How you start                          | Reads *launchSettings.json* | Opens browser at `/graphql` | Hot-reload |
| -------------------------------------- | --------------------------- | --------------------------- | ---------- |
| **VS / Rider (F5)**                    | ✅ yes                       | ✅ yes                       | ✅          |
| **`dotnet watch run`**                 | ✅ yes                       | ✅ yes                       | ✅          |
| **`dotnet run`**                       | 🚫 no (default)             | 🚫                          | 🚫         |
| **`dotnet run --launch-profile http`** | ✅ yes (selected profile)    | ✅ yes                       | 🚫         |


# Git Workflow

> A lightweight, single-developer-friendly flow that still follows industry best-practices.
> Adopt it now; add CI/CD later without changing habits.

---

## 1  Branching Model

| Branch name          | Purpose                                          | Golden rules                                                     |
|----------------------|--------------------------------------------------|------------------------------------------------------------------|
| **`main`**           | Always deployable & green. Release tags (`v0.3.0`) are cut here. | **Never commit directly.** Everything merges via PR. |
| **`feature/*`**      | New code – UI, API endpoints, refactors.         | Rebase on `main` before opening PR. (`git fetch origin && git rebase origin/main`) |
| **`bugfix/*`**       | Fixes for code **not yet released**.             | Same rules as feature branches. |
| **`hotfix/*`**       | Emergency fixes to a tagged production release.  | Merge → tag immediately (`git tag -a v0.3.1 -m "hotfix" && git push --tags`). |

<details>
<summary>📜 Naming examples</summary>

* `feature/budget-crud`
* `bugfix/login-nullref`
* `hotfix/v0.3.0-reset-password`
</details>

---

## 2  Commits & Pull-Requests

### Conventional Commits (required)

```text
feat(api): add POST /budget endpoint
fix(auth): reject weak passwords
chore(ci): add dotnet-format check
````
<details> 
<summary>🌱 Commit garden rules</summary>

- One logical change per commit.

- Start the subject with feat, fix, chore, refactor, docs, test, or build.

- Prefer the imperative mood: “add”, “remove”, “refactor”, not “added”, “removed”.

</details>

### Self-reviewed PRs (even when solo)

#### 0 · Sync and clean trunk
```bash
git switch main
git pull --rebase           # bring local main up to date with origin/main
````
#### 1 · Create the branch and push your work
```bash
git switch -c feature/budget-crud
# hack, test, repeat …

git add .
git commit -m "feat(api): add budget CRUD endpoints"

git fetch origin
git rebase origin/main        # keep history linear

git push -u origin feature/budget-crud
gh pr create -f               # or open PR in GitHub UI
````

#### 2 · Merge when green
```bash
gh pr merge --rebase --delete-branch   # same as “Rebase & Merge” in the GitHub UI
````
