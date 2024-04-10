using ChatApp.DataContexts;
using ChatApp.Models;
using ChatShared.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.DataServices;

public class UserDataService_Local
{
  private readonly SQLiteDBContext _context;
  public UserDataService_Local(SQLiteDBContext context)
  {
    _context = context;
  }
}
