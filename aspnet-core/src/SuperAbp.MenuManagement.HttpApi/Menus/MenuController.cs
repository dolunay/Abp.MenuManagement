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
        protected IMenuAppService MenuAppService { get; }

        public MenuController(IMenuAppService menuAppService)
        {
            MenuAppService = menuAppService;
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual async Task<GetMenuForEditorOutput> GetEditorAsync(Guid id)
        {
            return await MenuAppService.GetEditorAsync(id);
        }

        /// <summary>
        /// 所有
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public virtual async Task<ListResultDto<MenuListDto>> GetAllListAsync()
        {
            return await MenuAppService.GetAllListAsync();
        }

        /// <summary>
        /// 根
        /// </summary>
        /// <returns></returns>
        [HttpGet("root")]
        public virtual async Task<ListResultDto<MenuTreeNodeDto>> GetRootAsync()
        {
            return await MenuAppService.GetRootAsync();
        }

        /// <summary>
        /// 下级
        /// </summary>
        /// <param name="id">父Id</param>
        /// <returns></returns>
        [HttpGet("{id}/children")]
        public virtual async Task<ListResultDto<MenuTreeNodeDto>> GetChildrenAsync(Guid id)
        {
            return await MenuAppService.GetChildrenAsync(id);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        [HttpGet]
        public virtual async Task<PagedResultDto<MenuListDto>> GetListAsync(GetMenusInput input)
        {
            return await MenuAppService.GetListAsync(input);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<MenuListDto> CreateAsync(MenuCreateDto input)
        {
            return await MenuAppService.CreateAsync(input);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public virtual async Task<MenuListDto> UpdateAsync(Guid id, MenuUpdateDto input)
        {
            return await MenuAppService.UpdateAsync(id, input);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual async Task DeleteAsync(Guid id)
        {
            await MenuAppService.DeleteAsync(id);
        }
    }
}