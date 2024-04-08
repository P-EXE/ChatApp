namespace ChatShared.Models;

public class BearerToken
{
  public TokenType TokenType { get; set; }
  public string AccessToken { get; set; }
  public TimeSpan ExpiresIn { get; set; }
  public string RefreshToken {  get; set; }
}

public enum TokenType
{
  Bearer,
  Other
}
