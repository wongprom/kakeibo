// Program.cs

using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Npgsql; // ← add this
using test_next_13_backend_cSharp_Project.Data;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

string host = Environment.GetEnvironmentVariable("HOST") ?? "";
string port = Environment.GetEnvironmentVariable("PORT") ?? "5432";
string database = Environment.GetEnvironmentVariable("DATABASE") ?? "postgres";
string user = Environment.GetEnvironmentVariable("USER") ?? "postgres";
string password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "";


Console.WriteLine($"[DEBUG] HOST      = {host}");
Console.WriteLine($"[DEBUG] PORT      = {port}");
Console.WriteLine($"[DEBUG] DATABASE  = {database}");
Console.WriteLine($"[DEBUG] USER      = {user}");
Console.WriteLine(
  $"[DEBUG] PASSWORD  = {(string.IsNullOrWhiteSpace(password) ? "⚠️  MISSING" : new string('*', password.Length))}");
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
  SslMode = SslMode.Require, // Supabase forces SSL                    // dev only
  KeepAlive = 30, // survives NAT idle-timeouts
  Pooling = true,
  MaxPoolSize = 100
};
string connectionString = csb.ConnectionString;

builder.Services.AddDbContextPool<KakeiboDbContext>(options =>
  options.UseNpgsql(connectionString)
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// Light-weight connectivity check (async, no table scan)
using var scope = app.Services.CreateScope();
var ctx = scope.ServiceProvider.GetRequiredService<KakeiboDbContext>();
if (!await ctx.Database.CanConnectAsync())
  throw new Exception("❌ EF Core could not reach Supabase");
Console.WriteLine("✅ DB connectivity confirmed");

app.Run();