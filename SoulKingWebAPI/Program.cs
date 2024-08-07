using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SoulKingWebAPI.Data;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
  options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
  {
    Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
    In = ParameterLocation.Header,
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey
  });
  options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Add AddAuthentication Scheme
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
    options.TokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
        builder.Configuration.GetSection("Secrets:Token").Value!)),
      ValidateIssuer = false,
      ValidateAudience = false
    };
  });

// Connect db
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Add Cores policy
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAll",
      policy =>
      {
        var origin = builder.Configuration["WebApplication:Host"];

        if (origin == null)
        {
          policy.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();

          return;
        }

        policy.WithOrigins(origin)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
      });
});

// Add IWebHostEnvironment to the services
builder.Services.AddSingleton(builder.Environment);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
