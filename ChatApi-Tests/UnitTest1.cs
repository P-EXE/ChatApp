using AutoMapper;
using ChatApi.DataContexts;
using ChatShared.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ChatApi_Tests;

public class UnitTest1 : IDisposable
{
  private readonly DbConnection _connection;
  private readonly DbContextOptions<SQLDBContext> _contextOptions;
  private readonly IMapper _mapper;
  private readonly AppUser _user;

  public UnitTest1(IMapper mapper)
  {
    _connection = new SqliteConnection("Filename=:memory:");
    _connection.Open();

    _contextOptions = new DbContextOptionsBuilder<SQLDBContext>()
      .UseSqlite(_connection)
      .Options;

    using SQLDBContext context = new SQLDBContext(_contextOptions);

    _mapper = mapper;
  }

  SQLDBContext CreateContext() => new SQLDBContext(_contextOptions);
  public void Dispose() => _connection.Dispose();
}