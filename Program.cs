using Roadtrip.Utilities;
using Roadtrip.Clients;

var builder = WebApplication.CreateBuilder(args);

//Get an API Key
do
{
    Console.Write("Enter your Google API key:");
    GMapsHttpClient.apiKey = Console.ReadLine();

} while (GMapsHttpClient.apiKey == null);

// Add services to the container.
builder.Services.AddControllers();

//Add Http Client
builder.Services.AddGMapsHttpClient<PlacesClient>();
builder.Services.AddGMapsHttpClient<RoutesClient>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
