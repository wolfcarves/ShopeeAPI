using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var services = builder.Services;

services.AddControllers()
    .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
        }
    );

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddRouting(opt => opt.LowercaseUrls = true);
services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


services.AddApplicationServices();
services.AddLogging();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
