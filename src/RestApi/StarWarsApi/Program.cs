using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
bool seedData = false;
string cnxString = string.Empty;

// Seed the data and create the databse and exit.
// This should be called from your CI/CD pipeline
if (args.Length == 2 && args[0].ToLower() == "seeddata")
{
    cnxString = args[1];
    seedData = true;
}
else 
{
    cnxString = builder.Configuration.GetConnectionString("StarWarsDb");
}

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StarWarsContext>(x => x.UseSqlServer(cnxString));
builder.Services.AddTransient<DataSeeder>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Seed the data, this should be called from CI/CD
// and exit
if (seedData) 
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }

    return;
}


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
