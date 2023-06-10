using Microsoft.AspNetCore.Authentication.Cookies;
using SampleSite.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(c =>
{
    c.Cookie.Name = "LoginCookie";
    c.LoginPath = "/Account/Login";
    c.LogoutPath = "/Account/Logout";
    c.ExpireTimeSpan = TimeSpan.FromMinutes(50);
    c.SlidingExpiration = true;

});


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

app.UseRouting();  // geli�tirilen bu uygulamada routing aktif oldu
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "blog",
//    pattern: "blog/{*article}",
//    defaults: new { controller = "Blog", action = "Article" });

app.MapGet("/Ders", async context =>
{
    await context.Response.WriteAsync("Ders route kullan�ld�.");
});




DataContext veriler = new DataContext();

DataContext.globalDuties.Add(new Duty { Name = "Tar�m Projesi Takibi", TimeInDays = 10 });
DataContext.globalDuties.Add(new Duty { Name = "Personel Kontrol�", TimeInDays = 7 });
DataContext.globalDuties.Add(new Duty { Name = "Finans Tablosu Haz�rlama", TimeInDays = 3 });
DataContext.globalDuties.Add(new Duty { Name = "�retim Band� Kontrol�", TimeInDays = 15 });

app.Run();
