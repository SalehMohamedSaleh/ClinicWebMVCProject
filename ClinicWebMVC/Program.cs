using ClinicServices.Doctors.Commands.SoftDeleteDoctor;
using ClinicInfrastructure;
using MediatR;

namespace ClinicWebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // ≈÷«›… MediatR Ê ”ÃÌ· Ã„Ì⁄ «·‹ Handlers «·„ÊÃÊœ… ›Ì Assembly «·Œ«’ »ÿ»ﬁ… «·‹ Application
            // «·Õ· «·’ÕÌÕ:
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddMediatR(typeof(SoftDeleteDoctorCommand).Assembly);
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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
