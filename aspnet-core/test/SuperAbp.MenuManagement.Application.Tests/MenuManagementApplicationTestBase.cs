using SuperAbp.MenuManagement.EntityFrameworkCore;
using System;

namespace SuperAbp.MenuManagement;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class MenuManagementApplicationTestBase : MenuManagementTestBase<MenuManagementApplicationTestModule>
{
    protected virtual void UsingDbContext(Action<MenuManagementDbContext> action)
    {
        using (var dbContext = GetRequiredService<MenuManagementDbContext>())
        {
            action.Invoke(dbContext);
        }
    }

    protected virtual T UsingDbContext<T>(Func<MenuManagementDbContext, T> action)
    {
        using (var dbContext = GetRequiredService<MenuManagementDbContext>())
        {
            return action.Invoke(dbContext);
        }
    }
}
