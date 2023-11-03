using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Books.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BooksDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BooksDbContext") ?? throw new InvalidOperationException("Connection string 'BooksDbContext' not found.")));

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
else
{
    using var serviceScope = app.Services.CreateScope();
    var db = serviceScope.ServiceProvider.GetService<BooksDbContext>();
    SeedData.PopulateBooks(db!);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
