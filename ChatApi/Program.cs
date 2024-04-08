using ChatApi.DataContexts;
using ChatApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace ChatApi;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen(options =>
    {
      options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
      {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
      });
      options.OperationFilter<SecurityRequirementsOperationFilter>();
    });

    builder.Services.AddDbContext<SQLDBContext>(options =>
      options.UseSqlServer(
        builder.Configuration.GetConnectionString("ChatDB-SQLConnection")
      )
    );

    builder.Services.AddAuthorization();
    builder.Services.AddIdentityApiEndpoints<User>()
      .AddEntityFrameworkStores<SQLDBContext>();

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
      app.UseSwagger();
      app.UseSwaggerUI();
    }

    app.MapGroup("/api/user").MapIdentityApi<User>();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
  }
}
