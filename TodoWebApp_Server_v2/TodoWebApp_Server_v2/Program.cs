using TodoWebApp_Server_v2.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Persistence
builder.Services.AddPersistanceSetup(builder.Configuration);

//Swagger
builder.Services.AddSwaggerSetup();

//Auth
builder.Services.AddAuthSetup(builder.Configuration);

//Application
builder.Services.AddApplicationSetup();



var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors("MySite");
app.UseCors("Product");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
