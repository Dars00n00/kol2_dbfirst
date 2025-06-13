using kol2.Data;
using kol2.Services;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(
    "appsettings.json", 
    optional: false, 
    reloadOnChange: true
);

builder.Services.AddDbContext<_2019sbdContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IEventsService, EventsService>();

builder.Services.AddAuthorization(); 
builder.Services.AddControllers(); 

builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new()
    {
        Title = "kol2", 
        Version = "v1",
        Description = "apbd kol2 przykładowe - db first",
        Contact = new()
        {
            Name = "Dariusz",
            Email = "xxxxx@gmail.com",
            Url = new Uri("https://github.com/Dars00n00")
        }
    });
});

var app = builder.Build(); 

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "przykladowe_kol1_apbd");
    c.DocExpansion(DocExpansion.List);
    c.DefaultModelExpandDepth(0);
    c.DisplayRequestDuration();
    c.EnableFilter();
});


app.UseAuthorization();
app.MapControllers(); 

app.Run();
