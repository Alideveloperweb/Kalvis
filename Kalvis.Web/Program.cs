using Kalvis.Configuration;
using Kalvis.Configuration.CategoryConfig;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

#region Configur

string Connection = builder.Configuration.GetConnectionString("DefaultConnection");
ConnectionConfig.Configur(builder.Services, Connection);
CategoryConfiguration.Configure(builder.Services);

#endregion

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
