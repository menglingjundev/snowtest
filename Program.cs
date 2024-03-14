var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

var port = Environment.GetEnvironmentVariable("PORT");
if (port == null)
{
    // �f�o�b�O���s�p
    app.Run();
}
else
{
    //Cloud Run �p
    var url = $"http://0.0.0.0:{port}";
    var target = Environment.GetEnvironmentVariable("TARGET") ?? "World";

    app.MapGet("/", () => $"Hello {target}!");

    app.Run(url);
}