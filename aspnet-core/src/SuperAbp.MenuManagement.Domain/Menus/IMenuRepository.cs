using System;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.MenuManagement.Menus
{
    public interface IMenuRepository : IRepository<Menu, Guid>
    {
    }
}