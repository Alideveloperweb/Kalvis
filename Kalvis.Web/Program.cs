using Kalvi.Configuration.TicketConfig;
using Kalvis.Common.Sender;
using Kalvis.Configuration;
using Kalvis.Configuration.BlogConfig;
using Kalvis.Configuration.CategoryConfig;
using Kalvis.Configuration.CommentConfig;
using Kalvis.Configuration.CourseConfig;
using Kalvis.Configuration.DisCountConfig;
using Kalvis.Configuration.NotificationConfig;
using Kalvis.Configuration.OrderConfig;
using Kalvis.Configuration.PermissionConfig;
using Kalvis.Configuration.UserConfig;

var builder = WebApplication.CreateBuilder(args);
 const string CoockieName = "KalviLogin";

          



#region Claim

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(CoockieName)
    .AddCookie(CoockieName, opetion =>
    {
        opetion.LoginPath = "/Account/Login";
        opetion.LogoutPath = "/Account/LogOut";
        opetion.ExpireTimeSpan =
        TimeSpan.FromDays(31);
    });

#endregion

#region Configur

string Connection = builder.Configuration.GetConnectionString("DefaultConnection");

ConnectionConfig.Configur(builder.Services, Connection);
CategoryConfiguration.Configure(builder.Services);
UserConfiguration.Configure(builder.Services);
CourseConfiguration.Configure(builder.Services);
BlogConfiguration.Configure(builder.Services);
CourseDisCountConfiguration.Configure(builder.Services);
CourseCommentConfiguration.Configure(builder.Services);
NotificationConfiguration.Configure(builder.Services);
TicketConfiguration.Configure(builder.Services);
PermissionConfiguration.Configure(builder.Services);
OrderConfiguration.Configure(builder.Services);

builder.Services.AddTransient<IViewRenderService, RenderViewToString>();

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
