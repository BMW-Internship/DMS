using Dapper;
using DMS_Internship.Backend.Setup;
using DMS_Internship.Backend.VehicleServices;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<VehicleService>();
builder.Services.AddSingleton<DatabaseInit>();

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var databaseInit = app.Services.GetRequiredService<DatabaseInit>();
databaseInit.IntDatabase();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
  
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
app.UseSwagger();
app.UseSwaggerUI();

app.Run();



