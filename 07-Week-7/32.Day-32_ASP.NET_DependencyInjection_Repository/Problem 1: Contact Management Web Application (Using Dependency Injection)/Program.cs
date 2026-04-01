using WebApplication2.Services;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register Service (DI)
            builder.Services.AddSingleton<IContactService, ContactService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.UseRouting();

            app.MapStaticAssets();
            // Default Route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Contact}/{action=ShowContacts}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
