using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Repositories;
using Siemens.Internship2026.GradeBook.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemStatisticsService, ItemStatisticsService>();

builder.Services.AddHttpClient<IItemStatisticsRepository, ExternalEndpointItemRepository>();
builder.Services.AddHttpClient<IItemRepository,ExternalEndpointItemRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
