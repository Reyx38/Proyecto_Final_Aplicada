using Proyecto_Final_Aplicada.Components;
using Proyecto_Final.Services.DI;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegistarService();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Agregando services de Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o =>
    {
        o.Cookie.Name = "auth_token";
        o.LoginPath = "/StartSession";
        o.Cookie.MaxAge = TimeSpan.FromMinutes(45);
        o.AccessDeniedPath = "/access-denied";
    });
builder.Services.AddAuthentication();
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// Middlewares
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
