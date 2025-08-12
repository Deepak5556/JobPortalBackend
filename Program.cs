using JobPortalBackend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<JobPortalContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21))
    ));

// CORS
const string AllowAll = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAll, policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
    );
    // Example: restrict to your frontend during production
    // options.AddPolicy("FrontendOnly", policy =>
    //     policy.WithOrigins("http://localhost:5173", "https://your-frontend.com")
    //           .AllowAnyHeader()
    //           .AllowAnyMethod()
    // );
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Optional but recommended
app.UseHttpsRedirection();

// The order matters: Routing -> CORS -> AuthZ -> Endpoints
app.UseRouting();

app.UseCors(AllowAll);
// For restricted policy:
// app.UseCors("FrontendOnly");

app.UseAuthorization();

app.MapControllers();

app.Run();
