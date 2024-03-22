using Equipment_Placing_Service.BLL.Services.Interfaces;
using Equipment_Placing_Service.BLL.Services;
using Equipment_Placing_Service.DAL.Context;
using Equipment_Placing_Service.DAL.Repositories.Interfaces;
using Equipment_Placing_Service.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Equipment_Placing_Service.BLL.MappingProfiles;

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

app.Run();