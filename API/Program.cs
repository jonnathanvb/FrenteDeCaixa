using System.Reflection;
using System.Text;
using API.Config;
using API.IoC;
using Infra.Mapper;
using Infra.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Versioning;

var builder = WebApplication.CreateBuilder(args);


// Configure appsettings
var configurationSectionToken = builder.Configuration.GetSection("Token");
var jwtConfig = configurationSectionToken.Get<JwtConfig>();
builder.Services.Configure<JwtConfig>(configurationSectionToken);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
});


// Conexão
builder.Services.AddDbContext<Context>((options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"),
        settings => settings.EnableRetryOnFailure().CommandTimeout(900));
});


// TOKEN
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfig?.Autenticador,
            ValidAudience = jwtConfig?.Aplicativo,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig?.ChaveSecreta ?? ""))
        };
    });


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.Configure<SwaggerConfiguration>(builder.Configuration.GetSection(nameof(SwaggerConfiguration)));
builder.Services.AddControllers();
builder.Services.AddApiVersionWithExplorer()
    .AddSwaggerOptions()
    .AddSwaggerGen(x =>
    {
        x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer {{Value}}'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
        x.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });

        x.ExampleFilters();
    });

builder.Services.Inject();
builder.Services.AutoMapperStartup();
builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
builder.Services.AddCors(options =>
{
    options.AddPolicy("AnyOrigin",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AnyOrigin");
app.UseRouting();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>  x.EnablePersistAuthorization());
}

app.Run();