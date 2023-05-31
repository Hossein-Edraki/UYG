using Microsoft.EntityFrameworkCore;
using UYG.Api.Common;
using UYG.Api.DBContext;
using UYG.Api.Repository;
using UYG.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AppConfig>(builder.Configuration.GetSection("AppConfig"));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddDbContextPool<UYGDBContext>(o => {
    var connectionString = builder.Configuration.GetConnectionString("UYGDBContext");
    o.UseSqlServer(connectionString);
});

var app = builder.Build();

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
