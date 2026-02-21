using testapi.DB;
using Microsoft.EntityFrameworkCore;
using testapi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IExchange, Exchange>();
builder.Services.AddSignalR();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policyBuilder =>
    {
        policyBuilder.SetIsOriginAllowed(_ => true)
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowCredentials(); 
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");

app.MapHub<NotificationsHub>("/hubs/notifications");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
