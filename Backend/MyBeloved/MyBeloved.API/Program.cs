
using Microsoft.EntityFrameworkCore;
using MyBeloved.API.DataContext;
using MyBeloved.API.Services.AccountsServices;
using MyBeloved.API.Services.CategoriesServices;
using MyBeloved.API.Services.NotebooksServices;
using MyBeloved.API.Services.PagesServices;
using MyBeloved.API.Services.PartnerServices;

namespace MyBeloved.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<INotebookService, NotebookService>();
            builder.Services.AddScoped<IPageService, PageService>();
            builder.Services.AddScoped<IPartnerService, PartnerService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
