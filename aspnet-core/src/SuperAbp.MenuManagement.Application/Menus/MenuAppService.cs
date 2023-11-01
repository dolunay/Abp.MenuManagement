using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SuperAbp.MenuManagement.Menus;
using SuperAbp.MenuManagement.Permissions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.MenuManagement.Menus
{
    [Authorize(MenuManagementPermissions.Menus.Default)]
    public class MenuAppService : MenuManagementAppService, IMenuAppService
    {
        protected IMenuRepository MenuRepository { get; }

        public MenuAppService(
            IMenuRepository menuRepository)
        {
            MenuRepository = menuRepository;
        }

        public virtual async Task<ListResultDto<MenuListDto>> GetAllListAsync()
        {
            var menus = await MenuRepository.GetListAsync();
            return new ListResultDto<MenuListDto>(ObjectMapper.Map<List<Menu>, List<MenuListDto>>(menus));
        }

        public virtual async Task<ListResultDto<MenuTreeNodeDto>> GetRootAsync()
        {
            var menus = await MenuRepository.GetListAsync(m => m.ParentId == null);
            List<MenuTreeNodeDto> treeNodes = await Menu2TreeNodeAsync(menus);
            return new ListResultDto<MenuTreeNodeDto>(treeNodes);
        }

        public virtual async Task<ListResultDto<MenuTreeNodeDto>> GetChildrenAsync(Guid id)
        {
            var menus = await MenuRepository.GetListAsync(m => m.ParentId == id);
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
                treeNode.IsLeaf = !await MenuRepository.AnyAsync(m => m.ParentId == menu.Id);
                treeNodes.Add(treeNode);
            }
            return treeNodes;
        }

        public virtual async Task<PagedResultDto<MenuListDto>> GetListAsync(GetMenusInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var menuQueryable = await MenuRepository.WithDetailsAsync();
            var tempQuery = menuQueryable
                .WhereIf(input.ParentId.HasValue, m => m.ParentId == input.ParentId)
                .WhereIf(!string.IsNullOrEmpty(input.Name), m => m.Name.Contains(input.Name));

            long totalCount = await AsyncExecuter.CountAsync(tempQuery);

            var entities = await AsyncExecuter.ToListAsync(tempQuery
                .OrderBy(input.Sorting ?? MenuConsts.DefaultSorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            var dtos = ObjectMapper.Map<List<Menu>, List<MenuListDto>>(entities);

            return new PagedResultDto<MenuListDto>(totalCount, dtos);
        }

        public virtual async Task<GetMenuForEditorOutput> GetEditorAsync(Guid id)
        {
            Menu entity = await MenuRepository.GetAsync(id);

            return ObjectMapper.Map<Menu, GetMenuForEditorOutput>(entity);
        }

        [Authorize(MenuManagementPermissions.Menus.Create)]
        public virtual async Task<MenuListDto> CreateAsync(MenuCreateDto input)
        {
            var entity = ObjectMapper.Map<MenuCreateDto, Menu>(input);
            entity = await MenuRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<Menu, MenuListDto>(entity);
        }

        [Authorize(MenuManagementPermissions.Menus.Update)]
        public virtual async Task<MenuListDto> UpdateAsync(Guid id, MenuUpdateDto input)
        {
            Menu entity = await MenuRepository.GetAsync(id);
            entity = ObjectMapper.Map(input, entity);
            entity = await MenuRepository.UpdateAsync(entity);
            return ObjectMapper.Map<Menu, MenuListDto>(entity);
        }

        [Authorize(MenuManagementPermissions.Menus.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            if (await MenuRepository.AnyByParentIdAsync(id))
            {
                throw new UserFriendlyException("存在子菜单，无法删除");
            }

            await MenuRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        protected virtual async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(MenuSettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}