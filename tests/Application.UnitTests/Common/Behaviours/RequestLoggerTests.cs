using Microsoft.Extensions.Logging;
using Moq;
using movie_basic.Application.Common.Behaviours;
using movie_basic.Application.Common.Interfaces;
using movie_basic.Application.Features.User;
using NUnit.Framework;

namespace movie_basic.Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    private Mock<ILogger<AddUserCommand>> _logger = null!;
    private Mock<ICurrentUserService> _currentUserService = null!;
    private Mock<IIdentityService> _identityService = null!;

    [SetUp]
    public void Setup()
    {
        _logger = new Mock<ILogger<AddUserCommand>>();
        _currentUserService = new Mock<ICurrentUserService>();
        _identityService = new Mock<IIdentityService>();
    }

    [Test]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _currentUserService.Setup(x => x.UserId).Returns(Guid.NewGuid().ToString());

        var requestLogger = new LoggingBehaviour<AddUserCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);

        await requestLogger.Process(new AddUserCommand { UserName = "account.2", Password = "Movie@2022" }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
    }
}
