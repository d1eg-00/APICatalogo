using System.Text.Json.Serialization;
using APICatalogo.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
      .AddJsonOptions(Options => 
        Options.JsonSerializerOptions
          .ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



  string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection")!;

  builder.Services.AddDbContext<AppDbContext>(Options => 
                      Options.UseMySql(mySqlConnection, 
                      ServerVersion.AutoDetect(mySqlConnection)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

  app.UseSwagger();
  app.UseSwaggerUI();
    //app.MapOpenApi();
    //app.UseSwaggerUI(options => 
    //options.SwaggerEndpoint("/openapi/v1.json", "weather api"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
