using CLINICAL.Api.Extensions.Middleware;
using CLINICAL.Application.UseCase.Extensions;
using CLINICAL.Persistence.Extensions;
using CLINICAL.Infrastructure.Extensions;
using CLINICAL.Api.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddInjectionPersistence()
    .AddInjectionApplication()
    .AddInjectionInfrastructure(builder.Configuration)
    .AddAuthentication(builder.Configuration);

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.AddMiddleware();

app.MapControllers();

app.Run();
