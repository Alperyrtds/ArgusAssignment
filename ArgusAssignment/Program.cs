using ArgusAssignment.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEntityFrameworkSqlServer();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//TODO: Cors politikas� eklendi frontend den istek atabilmek i�in gerekli izin politikas�
builder.Services.AddCors(p => p.AddPolicy("ArgusAssignment", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
//TODO: appsettings.json da ki connectionStringi projeye i�lemek i�in gerekli yer
var connectionString = builder.Configuration.GetConnectionString("ArgusDB");
// TODO: connection stringin cal��t�rmak i�in gerekli yer
builder.Services.AddDbContext<ArgusDBContext>(option => 
{
    option.UseSqlServer(connectionString);
});
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
