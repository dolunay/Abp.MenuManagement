using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperAbp.MenuManagement.Menus;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.MenuManagement.Menus
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    [RemoteService(Name = MenuManagementRemoteServiceConsts.RemoteServiceName)]
    [Area(MenuManagementRemoteServiceConsts.ModuleName)]
    [Route("api/menus")]
    public class MenuController : MenuManagementController, IMenuAppService
    {
        private readonly IMenuAppService _menuAppService;

        public MenuController(IMenuAppService menuAppService)
        {
            _menuAppService = menuAppService;
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Task<GetMenuForEditorOutput> GetEditorAsync(Guid id)
        {
            return _menuAppService.GetEditorAsync(id);
        }

        /// <summary>
        /// 所有
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public Task<ListResultDto<MenuListDto>> GetAllListAsync()
        {
            return _menuAppService.GetAllListAsync();
        }

        /// <summary>
        /// 根
        /// </summary>
        /// <returns></returns>
        [HttpGet("root")]
        public Task<ListResultDto<MenuTreeNodeDto>> GetRootAsync()
        {
            return _menuAppService.GetRootAsync();
        }

        /// <summary>
        /// 下级
        /// </summary>
        /// <param name="id">父Id</param>
        /// <returns></returns>
        [HttpGet("{id}/children")]
        public Task<ListResultDto<MenuTreeNodeDto>> GetChildrenAsync(Guid id)
        {
            return _menuAppService.GetChildrenAsync(id);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        [HttpGet]
        public Task<PagedResultDto<MenuListDto>> GetListAsync(GetMenusInput input)
        {
            return _menuAppService.GetListAsync(input);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<MenuListDto> CreateAsync(MenuCreateDto input)
        {
            return _menuAppService.CreateAsync(input);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public Task<MenuListDto> UpdateAsync(Guid id, MenuUpdateDto input)
        {
            return _menuAppService.UpdateAsync(id, input);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _menuAppService.DeleteAsync(id);
        }
    }
}