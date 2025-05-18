// Program.cs

using Microsoft.EntityFrameworkCore;
using test_next_13_backend_cSharp_Project.Data;
using test_next_13_backend_cSharp_Project.GraphQL;
using test_next_13_backend_cSharp_Project.Mapping;

var builder = WebApplication.CreateBuilder(args);

/* ----------------------------------------------------------
 * 1️⃣  Connection string comes from configuration
 *     – appsettings.Development.json when ASPNETCORE_ENVIRONMENT=Development
 *     – user-secrets or env-vars override it automatically.
 * ---------------------------------------------------------- */
string conn =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DefaultConnection' not found. " +
        "Add it to appsettings.Development.json or user-secrets.");

/* ----------------------------------------------------------
 * 2️⃣  EF Core – plain Npgsql
 * ---------------------------------------------------------- */
builder.Services.AddDbContext<KakeiboDbContext>(options =>
    options.UseNpgsql(conn));

builder.Services.AddAutoMapper(typeof(UserProfile));

/* ----------------------------------------------------------
 * 3️⃣  GraphQL
 * ---------------------------------------------------------- */
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

/* ----------------------------------------------------------
 * 4️⃣  (Optional) quick connectivity test
 * ---------------------------------------------------------- */
var logger = app.Logger; // ILogger<Program>

await using (var scope = app.Services.CreateAsyncScope())
{
    var db = scope.ServiceProvider.GetRequiredService<KakeiboDbContext>();

    try
    {
        // minimal round-trip: opens, runs SELECT 1, closes
        var ok = await db.Database.ExecuteSqlRawAsync("SELECT 1");
        logger.LogInformation("✅ Supabase connection OK (SELECT 1 returned {Result})", ok);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "❌ Supabase connection FAILED");
        // optional: abort startup
        // Environment.Exit(1);
    }
}

app.MapGraphQL();
app.Run();
