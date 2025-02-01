using ClientServer_gRPC_Client.BLL.Services;
using ClientServer_gRPC_Client.DAL.Repositories;
using ClientServer_gRPC_Client.Domain.Repositories;
using ClientServer_gRPC_Client.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddGrpcClient<ClientServer_gRPC_Client.DAL.Protos.v1.StudentService.StudentServiceClient>(c =>
{
    c.Address = new Uri("https://localhost:7007"); //todo: change based on your uri.
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
