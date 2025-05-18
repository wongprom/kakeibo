
# Run Application
## Launch profiles

| How you start                          | Reads *launchSettings.json* | Opens browser at `/graphql` | Hot-reload |
| -------------------------------------- | --------------------------- | --------------------------- | ---------- |
| **VS / Rider (F5)**                    | ✅ yes                       | ✅ yes                       | ✅          |
| **`dotnet watch run`**                 | ✅ yes                       | ✅ yes                       | ✅          |
| **`dotnet run`**                       | 🚫 no (default)             | 🚫                          | 🚫         |
| **`dotnet run --launch-profile http`** | ✅ yes (selected profile)    | ✅ yes                       | 🚫         |
