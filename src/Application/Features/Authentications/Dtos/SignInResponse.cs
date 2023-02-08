namespace movie_basic.Application.Features.Authentications.Dtos;
public class SignInResponse
{
    public DateTime ExpiresIn { set; get; }

    public string AccessToken { set; get; }
}
