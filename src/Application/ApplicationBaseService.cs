using Microsoft.Extensions.Logging;
using movie_basic.Application.Common.Interfaces;

namespace movie_basic.Application;

public abstract class ApplicationBaseService<TService> where TService : class
{
    protected readonly ILogger<TService> _logger;
    protected readonly IApplicationDbContext _context;

    public ApplicationBaseService(
        ILogger<TService> logger,
        IApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
}
