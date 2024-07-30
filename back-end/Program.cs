using Microsoft.EntityFrameworkCore;
using SistemaDeLembretes.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddDbContext<ContextoDB>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("ContextoDB")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "LembretesTodo API", Version = "v1" });
});


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
 app.MapControllers();
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:5173")
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LembretesTodo API v1");
});

    app.MapControllerRoute(
    name: "lembrete",
    pattern: "api/[controller]/{action}/{id?}",
    defaults: new { controller = "Lembrete", action = "lembrete" });

app.Run();
