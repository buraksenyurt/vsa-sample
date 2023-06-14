using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.ServiceManager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IFeatureServiceManager, FeatureServiceManager>();
builder.Services.AddDbContext<MovieDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration["ConnectionStrings:DbConnStr"]);
        options.LogTo(Console.WriteLine, new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// // Seed dosyasındaki ilk verileri yüklemek bir seferlik çalıştırılan kod parçası
// // Bu nedenle yorum dışı bırakılmıştır.
// using (var scope = app.Services.CreateScope())
// {
//     var dataContext = scope.ServiceProvider.GetRequiredService<MovieDbContext>();
//     new Seed().SeedData(dataContext);
// }

app.UseAuthorization();
app.MapControllers();
app.Run();