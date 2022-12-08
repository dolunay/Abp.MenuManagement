using System;
using System.Threading.Tasks;
using SuperAbp.MenuManagement.Menus;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SuperAbp.MenuManagement.Menus
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    public interface IMenuAppService : IApplicationService
    {
        /// <summary>
        /// 所有
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<MenuListDto>> GetAllListAsync();

        /// <summary>
        /// 根
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<MenuTreeNodeDto>> GetRootAsync();

        /// <summary>
        /// 下级
        /// </summary>
        /// <param name="id">父Id</param>
        /// <returns></returns>
        Task<ListResultDto<MenuTreeNodeDto>> GetChildrenAsync(Guid id);

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        Task<PagedResultDto<MenuListDto>> GetListAsync(GetMenusInput input);

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<GetMenuForEditorOutput> GetEditorAsync(Guid id);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<MenuListDto> CreateAsync(MenuCreateDto input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<MenuListDto> UpdateAsync(Guid id, MenuUpdateDto input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}