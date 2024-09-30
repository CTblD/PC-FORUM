using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PC_FORUM.Data;
using PC_FORUM.Interfaces;
using PC_FORUM.Models;
using PC_FORUM.Services;

namespace PC_FORUM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ���������� MVC
            builder.Services.AddControllersWithViews();

            // ��������� ����������� � ���� ������ ����� �������� ApplicationDbContext
            // ���������� SQL Server � �������� ������ ����������� �� ����������������� ����� (appsettings.json)
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // ��������� ������ Identity ��� ���������� �������������� � ������
            // ���������� ������ ������������ User � ���� IdentityRole
            // ������ ������ � ���� ������ ����� �������� ApplicationDbContext
            builder.Services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddMemoryCache();
            builder.Services.AddSession();
            // ���������� ���� ��� ��������������
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            // ���������� ������� � ���������� ������������
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITopicRepository, TopicRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // ��������������� ���� HTTP-�������� �� HTTPS ��� ��������� ������������
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // ��������� ������������� � ���������� ��� ��������� �������� � ����������� ���������
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}