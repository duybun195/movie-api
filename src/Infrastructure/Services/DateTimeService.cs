using movie_basic.Application.Common.Interfaces;

namespace movie_basic.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
