//https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-9.0
//Install-Package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
//Install - Package Microsoft.EntityFrameworkCore.SqlServer
//https://www.learnentityframeworkcore.com/configuration/data-annotation-attributes/foreignkey-attribute

using Microsoft.EntityFrameworkCore;
using KJFZ.Data;


public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddSession(options => //Dodato za rad sa sesijom
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
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

        app.UseRouting();

        app.UseAuthorization();

        app.UseSession();

        app.MapControllerRoute( //Postavljamo prijavu za index
            name: "default",
            pattern: "{controller=Prijava}/{action=Index}/{id?}");

        CreateDbIfNotExists(app);

        app.Run();
    }

    private static void CreateDbIfNotExists(IHost host)
    {
        KJFZContext kjfzContext = new KJFZContext();
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                DbInitializer.Initialize(kjfzContext); //Pravimo bazu sa kontekstom
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }
    }
}