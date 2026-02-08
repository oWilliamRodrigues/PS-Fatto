using Microsoft.EntityFrameworkCore;
using PS_Fatto.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PS_FattoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PS_FattoContext") ?? throw new InvalidOperationException("Connection string 'PS_FattoContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tarefas}/{action=Index}/{id?}");

app.Run();
