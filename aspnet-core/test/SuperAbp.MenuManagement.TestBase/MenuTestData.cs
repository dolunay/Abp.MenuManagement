using System;
using Volo.Abp.DependencyInjection;

namespace SuperAbp.MenuManagement;

public class MenuTestData : ISingletonDependency
{
    public Guid MenuId { get; } = Guid.NewGuid();
}