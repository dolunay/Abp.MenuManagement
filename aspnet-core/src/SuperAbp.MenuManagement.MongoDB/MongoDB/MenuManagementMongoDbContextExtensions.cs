using Volo.Abp;
using Volo.Abp.MongoDB;

namespace SuperAbp.MenuManagement.MongoDB;

public static class MenuManagementMongoDbContextExtensions
{
    public static void ConfigureMenuManagement(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
