// Program.cs

using dotenv.net;

using Microsoft.EntityFrameworkCore;

using Npgsql; // ← add this
using test_next_13_backend_cSharp_Project.Data;
using test_next_13_backend_cSharp_Project.GraphQL;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

string host = Environment.GetEnvironmentVariable("HOST") ?? "";
string port = Environment.GetEnvironmentVariable("PORT") ?? "5432";
string database = Environment.GetEnvironmentVariable("DATABASE") ?? "postgres";
string user = Environment.GetEnvironmentVariable("USER") ?? "postgres";
string password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "";

// Fail fast if the secret is missing
if (string.IsNullOrWhiteSpace(password))
    throw new InvalidOperationException("Database password not loaded from .env");

// 👇 build with NpgsqlConnectionStringBuilder so nothing is accidentally malformed
var csb = new NpgsqlConnectionStringBuilder
{
    Host = host,
    Port = int.Parse(port),
    Database = database,
    Username = user,
    Password = password,
    SslMode = SslMode.Require, // Supabase forces SSL
    KeepAlive = 30, // survives NAT idle-timeouts
    Pooling = true,
    MaxPoolSize = 100
};
string connectionString = csb.ConnectionString;

builder.Services.AddDbContextPool<KakeiboDbContext>(options =>
    options.UseNpgsql(connectionString)
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

// Light-weight connectivity check (async, no table scan)
using var scope = app.Services.CreateScope();
var ctx = scope.ServiceProvider.GetRequiredService<KakeiboDbContext>();
if (!await ctx.Database.CanConnectAsync())
    throw new Exception("❌ EF Core could not reach Supabase");
Console.WriteLine("✅ DB connectivity confirmed");

app.MapGraphQL();
app.Run();
