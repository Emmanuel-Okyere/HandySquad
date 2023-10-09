using System.Text;
using HandySquad.Config;
using HandySquad.Data;
using HandySquad.Global_Exceptions;
using HandySquad.Repositories.Implementations;
using HandySquad.Repositories.Interfaces;
using HandySquad.Services.Implementations;
using HandySquad.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<DataContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("connection")));
//option.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
//registery repositories &bservices  
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IProfileImageRepository,IProfileImageRepository>();
builder.Services.AddScoped<IProfileImageService,ProfileImageService>();
builder.Services.AddScoped<ISkillSetReposiotry,SkillSetRepository>();
builder.Services.AddScoped<ISkillSetService,SkillSetService>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new NotFound404NotFoundException());
    options.Filters.Add(new Duplicate404ConflictException());
    options.Filters.Add(new BadRequest400BadRequestException());
    options.Filters.Add(typeof(ErrorHandlingAttributes));
}).AddNewtonsoftJson(option =>
{
    option.SerializerSettings.Converters.Add(new StringEnumConverter());
    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",new OpenApiInfo{Title = "HandySquad.API",Version = "v1"});
    options.AddSecurityDefinition("oauth2",new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        Description = "Standard Authorization header using the Bearer scheme",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http
    });
    
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration.GetSection("JWT:Issuer").Value,
            ValidAudience = builder.Configuration.GetSection("JWT:Audience").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("JWT:Key").Value!)
            )
        };
    });
builder.Services.AddAuthorization();

//Initialising AutoMapper
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();