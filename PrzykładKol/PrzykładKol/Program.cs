using Microsoft.EntityFrameworkCore;
using PrzykładKol.Properties.Data;

var builder = WebApplication.CreateBuilder(args);
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddAuthorization();

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<Database>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
        
app.MapControllers();

        

app.Run();



