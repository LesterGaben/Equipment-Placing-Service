using Equipment_Placing_Service.BLL.Services.Interfaces;
using Equipment_Placing_Service.BLL.Services;
using Equipment_Placing_Service.DAL.Context;
using Equipment_Placing_Service.DAL.Repositories.Interfaces;
using Equipment_Placing_Service.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Equipment_Placing_Service.BLL.MappingProfiles;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EquipmentPlacingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EquipmentPlacingDB")));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IManufacturingSpaceRepository, ManufacturingSpaceRepository>();
builder.Services.AddScoped<IEquipmentTypeRepository, EquipmentTypeRepository>();
builder.Services.AddScoped<IEquipmentPlacementContractRepository, EquipmentPlacementContractRepository>();

builder.Services.AddScoped<IManufacturingSpaceService, ManufacturingSpaceService>();
builder.Services.AddScoped<IEquipmentTypeService, EquipmentTypeService>();
builder.Services.AddScoped<IEquipmentPlacementContractService, EquipmentPlacementContractService>();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAll");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseExceptionHandler(appError => {
    appError.Run(async context => {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Response.ContentType = "application/json";

        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null) {
            var error = contextFeature.Error;

            if (error.Message.Contains("Insufficient space for the equipment.")) {
                
                var response = JsonSerializer.Serialize(new {
                    StatusCode = context.Response.StatusCode,
                    Message = "Insufficient space for the equipment."
                });
                await context.Response.WriteAsync(response);
            }
            else {
                var response = JsonSerializer.Serialize(new {
                    StatusCode = context.Response.StatusCode,
                    Message = error.Message
                });
                await context.Response.WriteAsync(response);
            }
        }
    });
});

app.Run();