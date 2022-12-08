using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SuperAbp.MenuManagement.Menus;
using SuperAbp.MenuManagement.Permissions;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.MenuManagement.Menus
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    [Authorize(MenuManagementPermissions.Menus.Default)]
    public class MenuAppService : MenuManagementAppService, IMenuAppService
    {
        private readonly IMenuRepository _menuRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="menuRepository"></param>
        public MenuAppService(
            IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        /// <summary>
        /// 所有
        /// </summary>
        /// <returns></returns>
        public virtual async Task<ListResultDto<MenuListDto>> GetAllListAsync()
        {
            var menus = await _menuRepository.GetListAsync();
            return new ListResultDto<MenuListDto>(ObjectMapper.Map<List<Menu>, List<MenuListDto>>(menus));
        }

        /// <summary>
        /// 根
        /// </summary>
        /// <returns></returns>
        public virtual async Task<ListResultDto<MenuTreeNodeDto>> GetRootAsync()
        {
            var menuQueryable = await _menuRepository.GetQueryableAsync();
            var menus = await AsyncExecuter.ToListAsync(menuQueryable.Where(m => m.ParentId == null));
            List<MenuTreeNodeDto> treeNodes = await Menu2TreeNodeAsync(menus);
            return new ListResultDto<MenuTreeNodeDto>(treeNodes);
        }

        /// <summary>
        /// 下级
        /// </summary>
        /// <param name="id">父Id</param>
        /// <returns></returns>
        public virtual async Task<ListResultDto<MenuTreeNodeDto>> GetChildrenAsync(Guid id)
        {
            var menuQueryable = await _menuRepository.GetQueryableAsync();
            var menus = await AsyncExecuter.ToListAsync(menuQueryable.Where(m => m.ParentId == id));
            List<MenuTreeNodeDto> treeNodes = await Menu2TreeNodeAsync(menus);
            return new ListResultDto<MenuTreeNodeDto>(treeNodes);
        }

        /// <summary>
        /// Menu转TreeNode
        /// </summary>
        /// <param name="menus">菜单</param>
        /// <returns></returns>
        private async Task<List<MenuTreeNodeDto>> Menu2TreeNodeAsync(List<Menu> menus)
        {
            List<MenuTreeNodeDto> treeNodes = new List<MenuTreeNodeDto>();
            foreach (Menu menu in menus)
            {
                MenuTreeNodeDto treeNode = ObjectMapper.Map<Menu, MenuTreeNodeDto>(menu);
                treeNode.IsLeaf = !await AsyncExecuter.AnyAsync(await _menuRepository.GetQueryableAsync(), m => m.ParentId == menu.Id);
                treeNodes.Add(treeNode);
            }
            return treeNodes;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        public virtual async Task<PagedResultDto<MenuListDto>> GetListAsync(GetMenusInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var menuQueryable = await _menuRepository.WithDetailsAsync(m=>m.Parent);
            var tempQuery = menuQueryable
                .WhereIf(input.ParentId.HasValue, m => m.ParentId == input.ParentId)
                .WhereIf(!string.IsNullOrEmpty(input.Name), m => m.Name.Contains(input.Name));

            long totalCount = await AsyncExecuter.CountAsync(tempQuery);

            var entities = await AsyncExecuter.ToListAsync(tempQuery
                .OrderBy(input.Sorting ?? "Sort DESC")
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            var dtos = ObjectMapper.Map<List<Menu>, List<MenuListDto>>(entities);

            return new PagedResultDto<MenuListDto>(totalCount, dtos);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual async Task<GetMenuForEditorOutput> GetEditorAsync(Guid id)
        {
            Menu entity = await _menuRepository.GetAsync(id);

            return ObjectMapper.Map<Menu, GetMenuForEditorOutput>(entity);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(MenuManagementPermissions.Menus.Create)]
        public virtual async Task<MenuListDto> CreateAsync(MenuCreateDto input)
        {
            var entity = ObjectMapper.Map<MenuCreateDto, Menu>(input);
            entity = await _menuRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<Menu, MenuListDto>(entity);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(MenuManagementPermissions.Menus.Update)]
        public virtual async Task<MenuListDto> UpdateAsync(Guid id, MenuUpdateDto input)
        {
            Menu entity = await _menuRepository.GetAsync(id);
            entity = ObjectMapper.Map(input, entity);
            entity = await _menuRepository.UpdateAsync(entity);
            return ObjectMapper.Map<Menu, MenuListDto>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [Authorize(MenuManagementPermissions.Menus.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _menuRepository.DeleteAsync(s => s.Id == id);
        }

        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        private async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(MenuSettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}