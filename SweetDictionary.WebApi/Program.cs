using Core.Repository;
using Microsoft.EntityFrameworkCore;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Repository.Repositories.Concretes;
using SweetDictionary.Service.Abstracts;
using SweetDictionary.Service.Concretes;
using SweetDictionary.Service.Mapings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddAutoMapper(typeof(MappingProfiles));



// Add services to the container.
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
