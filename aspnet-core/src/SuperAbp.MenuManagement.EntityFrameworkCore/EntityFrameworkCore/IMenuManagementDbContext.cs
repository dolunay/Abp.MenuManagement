using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.MenuManagement.EntityFrameworkCore;

[ConnectionStringName(MenuManagementDbProperties.ConnectionStringName)]
public interface IMenuManagementDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
