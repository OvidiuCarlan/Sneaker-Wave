using DAL.DBs;
using Logic.Interfaces;
using Logic.Logic;
using Microsoft.AspNetCore.Authentication.Cookies;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddScoped<IProductDataHandler, ProductDataHandler>();
        builder.Services.AddScoped<IProductManager, ProductManager>();
        builder.Services.AddScoped<IUserDataHandler, UserDataHandler>();
        builder.Services.AddScoped<IUserManager, UserManager>();
        builder.Services.AddScoped<IOrderManager, OrderManager>();
        builder.Services.AddScoped<IOrderDataHandler, OrderDataHandler>();
        builder.Services.AddScoped<IAddressDataHandler, AddressDataHandler>();
        builder.Services.AddScoped<ICardDataHandler, CardDataHandler>();
        builder.Services.AddScoped<IBonusCardDataHandler, BonusCardDataHandler>();
        builder.Services.AddScoped<IBonusCardManager, BonusCardManager>();
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/Error";
            });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("CustomPolicy", policy =>
            {
                //policy.AuthenticationSchemes.Add(CookieAuthenticationDefaults.AuthenticationScheme);
                policy.RequireAuthenticatedUser();
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseSession();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}