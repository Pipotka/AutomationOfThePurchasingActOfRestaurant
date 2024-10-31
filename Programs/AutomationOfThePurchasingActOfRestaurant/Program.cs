using Company.AutomationOfThePurchasingActOfRestaurant.Context;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.WriteRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Infrastructure;
using Company.AutomationOfThePurchasingActOfRestaurant.Infrastructure.AutoMapper;
using Company.AutomationOfThePurchasingActOfRestaurant.OpenXML.Excel.ComfortableOperations;
using Company.AutomationOfThePurchasingActOfRestaurant.OpenXML.Excel.ComfortableOperations.Interfaces;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.AutoMapper;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.OpenXML.Excel;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.ModelServices;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.OpenXML.Excel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;



builder.Services.AddControllers(config =>
{
    config.Filters.Add<PurchasingEntityExceptionFilter>();
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.UseAllOfToExtendReferenceSchemas();
    opt.IncludeXmlComments(xmlPath);
    opt.EnableAnnotations();
    
});

builder.Services.AddCors(optins =>
{
    optins.AddPolicy("DebugCorsPolicyName", config =>
    {
        config.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<PurchasingContext>(
    options =>
    {
        options.UseSqlServer(configuration
            .GetConnectionString(nameof(PurchasingContext)));
    }
    );

builder.Services.AddAutoMapper(typeof(PurchasingApiProfile).Assembly);
builder.Services.AddAutoMapper(typeof(PurchasingProfile).Assembly);

builder.Services.AddScoped<IDbReader>(x => 
x.GetRequiredService<PurchasingContext>());
builder.Services.AddScoped<IDbWriter>(x => 
x.GetRequiredService<PurchasingContext>());
builder.Services.AddScoped<IUnitOfWork>(x => 
x.GetRequiredService<PurchasingContext>());

builder.Services.AddSingleton<IPurchasingValidateService, PurchasingValidateService>();

builder.Services.AddScoped<IApproverService, ApproverService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeePositionService, EmployeePositionService>();
builder.Services.AddScoped<IFormKeyService, FormKeyService>();
builder.Services.AddScoped<IMeasurementUnitService, MeasurementUnitService>();
builder.Services.AddScoped<IMerchandiseService, MerchandiseService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IPurchaseFormService, PurchaseFormService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

builder.Services.AddScoped<IExcelTableService, ExcelTableService>();


builder.Services.AddScoped<IExcelCellFormattingOperations,
    ExcelCellFormattingOperations>();
builder.Services.AddScoped<IExcelCellOperations,
    ExcelCellOperations>();
builder.Services.AddScoped<IExcelDocumentOperations,
    ExcelDocumentOperations>();
builder.Services.AddScoped<IExcelSheetOperations,
    ExcelSheetOperations>();


builder.Services.AddScoped<IApproverReadRepository,
    ApproverReadRepository>();
builder.Services.AddScoped<IApproverWriteRepository,
    ApproverWriteRepository>();
builder.Services.AddScoped<IEmployeeReadRepository,
    EmployeeReadRepository>();
builder.Services.AddScoped<IEmployeeWriteRepository,
    EmployeeWriteRepository>();
builder.Services.AddScoped<IEmployeePositionWriteRepository,
    EmployeePositionWriteRepository>();
builder.Services.AddScoped<IEmployeePositionReadRepository,
    EmployeePositionReadRepository>();
builder.Services.AddScoped<IFormKeyWriteRepository,
    FormKeyWriteRepository>();
builder.Services.AddScoped<IFormKeyReadRepository,
    FormKeyReadRepository>();
builder.Services.AddScoped<IMeasurementUnitWriteRepository,
    MeasurementUnitWriteRepository>();
builder.Services.AddScoped<IMeasurementUnitReadRepository,
    MeasurementUnitReadRepository>();
builder.Services.AddScoped<IMerchandiseWriteRepository,
    MerchandiseWriteRepository>();
builder.Services.AddScoped<IMerchandiseReadRepository,
    MerchandiseReadRepository>();
builder.Services.AddScoped<IOrganizationWriteRepository,
    OrganizationWriteRepository>();
builder.Services.AddScoped<IOrganizationReadRepository,
    OrganizationReadRepository>();
builder.Services.AddScoped<IPurchaseFormWriteRepository,
    PurchaseFormWriteRepository>();
builder.Services.AddScoped<IPurchaseFormReadRepository,
    PurchaseFormReadRepository>();
builder.Services.AddScoped<ISupplierWriteRepository,
    SupplierWriteRepository>();
builder.Services.AddScoped<ISupplierReadRepository,
    SupplierReadRepository>();

var app = builder.Build();

app.UseCors("DebugCorsPolicyName");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutomationOfThePurchasingActOfRestaurant V1");
    });
    app.UseExceptionHandler("/Error");
    app.UseDeveloperExceptionPage();
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
