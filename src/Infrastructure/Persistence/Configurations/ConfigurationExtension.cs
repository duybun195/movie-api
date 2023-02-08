using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using movie_basic.Domain.Common;

namespace movie_basic.Infrastructure.Persistence.Configurations;
public static class ConfigurationExtension
{
    public static void ConfigurateBase<T, TKey>(this EntityTypeBuilder<T> builder, bool enableSoftDelete = true) where T : BaseAuditableEntity
    {
        builder.Property(x => x.Created).HasDefaultValueSql("getdate()");
        builder.Property(x => x.LastModified).HasDefaultValueSql("getdate()");
    }
}
