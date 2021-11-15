using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite.Design;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// protected override void OnConfiguring(DbContextOptionsBuilder options)
//         {
//              var configuration = new ConfigurationBuilder()
//                 .SetBasePath(Directory.GetCurrentDirectory())
//                 .AddJsonFile("appsettings.json")
//                 .Build();

//             var connectionString = configuration.GetConnectionString("AppDb");
//             options.UseSqlite(Configuration.GetConnectionString("API"));
//         }
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DBContext>(x => x.UseSqlite(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
using var scope=app.Services.CreateScope();
var services=scope.ServiceProvider;
try{
var context=services.GetRequiredService<DBContext>();
await context.Database.MigrateAsync();

    await Seed.SeedData(context);

}catch(Exception EX){
var logger=services.GetRequiredService<ILogger<Program>>();
logger.LogError(EX,"An Error occured here");
}
await app.RunAsync();
