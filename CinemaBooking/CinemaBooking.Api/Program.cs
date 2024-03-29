using CinemaBooking.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.ConfigureServices((hostContext, services) =>
{
    services.ConfigureAppSettings(hostContext.Configuration);
    services.ConfigureDbContext();
    services.ConfigureMappers();
    services.ConfigureApplicationServices();
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
