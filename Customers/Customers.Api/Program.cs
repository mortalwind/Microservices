using Addresss.Infrastructure.Abstraction;
using Customers.Infrastructure.Abstraction;
using Customers.Infrastructure.Repositories;
using Customers.Services;
using Microsoft.EntityFrameworkCore;
using Customers.Api.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using AutoMapper;
using Customers.Infrastructure.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddAutoMapper(typeof(CustomerProfile));


builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddDbContext<CustomerContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
});
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

//app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

DbPrepare.PopulateData(app);

app.Run();