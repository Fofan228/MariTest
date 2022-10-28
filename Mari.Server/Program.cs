using Mari.Application;
using Mari.Contracts.Common;
using Mari.Infrastructure;
using Mari.Server.Authentication;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);

    builder.Services.AddMariAuthentication(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        app.UseExceptionHandler(Routes.Server.ErrorController);
    }

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
}

app.Run();
