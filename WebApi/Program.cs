using Aplicacion.Services;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;
using Persistencia.Repository;
using WebAPI.Midleware;

using DotNetEnv;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;
using Aplicacion.Services.Implementations;
using Persistencia.Repository.Implementations;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

var keyVaultUrl = $"https://{Environment.GetEnvironmentVariable("KeyVaultUrl")}.vault.azure.net/";
var clientId = Environment.GetEnvironmentVariable("ClientId");
var clientSecret = Environment.GetEnvironmentVariable("ClientSecret");
var TenantId = Environment.GetEnvironmentVariable("TenantId");
builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), new ClientSecretCredential(TenantId, clientId, clientSecret));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string connectionString = "";

bool env = builder.Environment.IsDevelopment();
if (!env)
{
    connectionString = builder.Configuration.GetValue<string>("CONNECTION-STRING-ADM");
}else
{
    connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
}

var logger = LoggerFactory.Create(config =>
{
    config.AddConsole();
}).CreateLogger("Program");

logger.LogInformation("CADENA DE CONEXION: ENV: " + Environment.GetEnvironmentVariable("CONNECTION_STRING"));
logger.LogInformation("CADENA DE CONEXION KV: " + connectionString);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
                       options.UseSqlServer(connectionString),
            ServiceLifetime.Transient);





builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IUsuarioRolRepository), typeof(UsuarioRolRepository));
builder.Services.AddScoped(typeof(ActividadRepository), typeof(ActividadRepository));

builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped(typeof(IUsuarioRolService), typeof(UsuarioRolService));
builder.Services.AddScoped(typeof(ActividadService), typeof(ActividadService));



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);


string timeZoneId = builder.Configuration.GetValue<string>("TimeZone");
TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
// Configura la zona horaria por defecto para la aplicación
builder.Services.AddSingleton(timeZone);


builder.Services.AddCors(opt => {
    opt.AddPolicy(name: myAllowSpecificOrigins,
        builder => {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });


});





var app = builder.Build();





app.UseMiddleware<ExcepcionErroresMidleware>();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}


//if (app.Environment.IsDevelopment())
//{   
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();
app.Run();


