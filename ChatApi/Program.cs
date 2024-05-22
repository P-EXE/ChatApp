using ChatApi.DataContexts;
using ChatApi.Repos;
using ChatShared.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace ChatApi;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    #region Services

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

    #region Sqlite in Memory
    SqliteConnection sqliteConnection = new SqliteConnection(
      builder.Configuration.GetConnectionString("SQLiteConnection")
    );
    sqliteConnection.Open();
    builder.Services.AddDbContext<SQLDBContext>(options =>
      options.UseSqlite(sqliteConnection)
    );
    #endregion Sqlite in Memory

    #region SQLServer
    builder.Services.AddDbContext<SQLDBContext>(options =>
       options.UseSqlServer(
         builder.Configuration.GetConnectionString("ChatDB-SQLConnection")
       )
     );
    #endregion SQLServer

    builder.Services.AddAuthorization();
    builder.Services.AddIdentityApiEndpoints<AppUser>()
      .AddEntityFrameworkStores<SQLDBContext>();

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddScoped<IUserRepo, UserRepo>();
    builder.Services.AddScoped<IChatRepo, ChatRepo>();
    builder.Services.AddScoped<IMessageRepo, MessageRepo>();

    #endregion Services

    var app = builder.Build();

    #region App

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
      app.UseSwagger();
      app.UseSwaggerUI();
    }

    app.MapGroup("/api/user").MapIdentityApi<AppUser>();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

    #endregion App
  }
}
