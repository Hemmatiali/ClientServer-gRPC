using ClientServer_gRPC.BLL.Services;
using ClientServer_gRPC.DAL;
using ClientServer_gRPC.DAL.Repositories;
using ClientServer_gRPC.Domain.Repositories;
using ClientServer_gRPC.Domain.Services;
using ClientServer_gRPC.gRPC.Services;
using GrpcInfrastructures;
using Interceptors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc(options =>
{
    options.EnableDetailedErrors = true;
    options.Interceptors.Add<ExceptionInterceptor>();
});

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddDbContext<StudentDbContext>();
builder.Services.AddSingleton<ProtoFileProvider>();
builder.Services.AddGrpcReflection();

var app = builder.Build();
app.MapGrpcReflectionService();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();

// Config minimal Apis
app.MapGet("/protos", (ProtoFileProvider protoFileProvider) => Results.Ok((object?)protoFileProvider.GetAll()));
app.MapGet("/protos/v{version:int}/{protoName}",
    (ProtoFileProvider protoFileProvider, int version, string protoName) =>
    {
        string filePath = protoFileProvider.GetPath(version, protoName);
        return string.IsNullOrWhiteSpace(filePath) ? Results.NotFound() : Results.Ok(filePath);
    });
app.MapGet("/protos/v{version:int}/{protoName}/view",
   async (ProtoFileProvider protoFileProvider, int version, string protoName) =>
   {
       string fileContent = await protoFileProvider.GetContent(version, protoName);
       return string.IsNullOrWhiteSpace(fileContent) ? Results.NotFound() : Results.Text(fileContent);
   });

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
