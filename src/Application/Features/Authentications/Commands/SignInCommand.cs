using MediatR;
using movie_basic.Application.Features.Authentications.Dtos;

namespace movie_basic.Application.Features.Authentications;
public class SignInCommand : IRequest<SignInResponse>
{
    private string _userName;
    public string UserName
    {
        get
        {
            return string.IsNullOrEmpty(_userName) ? string.Empty : _userName.Trim();
        }
        set { _userName = value; }
    }

    private string _password;
    public string Password
    {
        get
        {
            return string.IsNullOrEmpty(_password) ? string.Empty : _password.Trim();
        }
        set { _password = value; }
    }
}
