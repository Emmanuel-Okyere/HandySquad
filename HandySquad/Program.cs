using HandySquad.Config;
using HandySquad.Data;
using HandySquad.Repositories.Implementations;
using HandySquad.Repositories.Interfaces;
using HandySquad.Services.Implementations;
using HandySquad.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<DataContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("connection")));
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new NotFound404NotFoundException());
    options.Filters.Add(new Duplicate404ConflictException());
    options.Filters.Add(new BadRequest400BadRequestException());
}).AddNewtonsoftJson(option =>
{
    option.SerializerSettings.Converters.Add(new StringEnumConverter());
    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
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

app.Run();