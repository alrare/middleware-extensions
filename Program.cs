using MyApp.MyAppCustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddTransient<CustomMiddleware>();

//app.UseMiddleware<CustomMiddleware>();

builder.Services.AddControllers();
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


//app.UseMiddleware();
app.UseCustomMiddleware1();
app.UseCustomMiddleware2();

app.Run(async (context) =>
{
    var response = context.Response;
    await context.Response.WriteAsync("Terminal Run() - 3 method executed\n");
    await context.Response.WriteAsync($"{response}\n");

});

app.Run();