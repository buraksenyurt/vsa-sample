using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.ServiceManager;

var builder = WebApplication.CreateBuilder(args);
ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    //builder.AddDebug();
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddDbContext<MovieDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration["ConnectionStrings:DbConnStr"]);
        options.LogTo(Console.WriteLine, new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
    });

builder.Services.AddScoped<IFeatureServiceManager, FeatureServiceManager>();

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