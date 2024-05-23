using AutoMapper;
using ChatApi.DataContexts;
using ChatShared.Models;

namespace ChatApi.Repos;

public class MessageRepo : IMessageRepo
{

  private readonly SQLDBContext _context;
  private readonly IMapper _mapper;

  public MessageRepo(SQLDBContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<Message?> CreateMessageInChatAsync(Message message)
  {

  }
}
