using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace SuperAbp.MenuManagement.Menus
{
    public sealed class MenuAppServiceTests : MenuManagementApplicationTestBase
    {
        private readonly MenuTestData _menuTestData;
        private readonly IMenuAppService _menuAppService;

        public MenuAppServiceTests()
        {
            _menuTestData = GetRequiredService<MenuTestData>();
            _menuAppService = GetRequiredService<IMenuAppService>();
        }

        [Fact]
        public async Task Should_Get_List()
        {
            var result = await _menuAppService.GetListAsync(new GetMenusInput());
            result.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Should_Get_For_Editor()
        {
            var result = await _menuAppService.GetEditorAsync(_menuTestData.MenuId);
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task Should_Create_A_Article()
        {
            var dto = new MenuCreateDto()
            {
                Name = "test_name",
                Permission = "test_permission",
                Group = false,
                HideInBreadcrumb = false,
                Icon = "test_icon",
                ParentId = _menuTestData.MenuId,
                Route = "test_route",
                Sort = 999
            };
            var articleDto = await _menuAppService.CreateAsync(dto);

            UsingDbContext(context =>
            {
                var article = context.Menus.FirstOrDefault(a => a.Id == articleDto.Id);
                article.ShouldNotBeNull();
                article.Name.ShouldBe(dto.Name);
                article.Permission.ShouldBe(dto.Permission);
                article.Group.ShouldBe(dto.Group);
                article.HideInBreadcrumb.ShouldBe(dto.HideInBreadcrumb);
                article.Icon.ShouldBe(dto.Icon);
                article.ParentId.ShouldBe(dto.ParentId);
                article.Route.ShouldBe(dto.Route);
                article.Sort.ShouldBe(dto.Sort);
            });
        }

        [Fact]
        public async Task Should_Update_A_Article()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                var dto = new MenuUpdateDto()
                {
                    Name = "new_name",
                    Permission = "new_permission",
                    Group = true,
                    HideInBreadcrumb = true,
                    Icon = "new_icon",
                    ParentId = null,
                    Route = "new_route",
                    Sort = 999
                };
                await _menuAppService.UpdateAsync(_menuTestData.MenuId, dto);
                UsingDbContext(context =>
                {
                    var menu = context.Menus.First(q => q.Id == _menuTestData.MenuId);
                    menu.Name.ShouldBe(dto.Name);
                    menu.Permission.ShouldBe(dto.Permission);
                    menu.Group.ShouldBe(dto.Group);
                    menu.HideInBreadcrumb.ShouldBe(dto.HideInBreadcrumb);
                    menu.Icon.ShouldBe(dto.Icon);
                    menu.ParentId.ShouldBe(dto.ParentId);
                    menu.Route.ShouldBe(dto.Route);
                    menu.Sort.ShouldBe(dto.Sort);
                });
            });
        }

        [Fact]
        public async Task Should_Delete_A_Article()
        {
            await _menuAppService.DeleteAsync(_menuTestData.MenuId);
        }
    }
}