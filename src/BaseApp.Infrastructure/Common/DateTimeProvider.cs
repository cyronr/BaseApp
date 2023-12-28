using BaseApp.Application.Common;

namespace BaseApp.Infrastructure.Common;

internal class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.UtcNow;

    public TimeSpan DateDiffrence(DateTime from, DateTime to)
    {
        return (from - to);
    }
}
