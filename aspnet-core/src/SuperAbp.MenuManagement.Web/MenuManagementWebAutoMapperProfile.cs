using AutoMapper;
using SuperAbp.MenuManagement.Menus;
using SuperAbp.MenuManagement.Web.Pages.Menus;

namespace SuperAbp.MenuManagement.Web;

public class MenuManagementWebAutoMapperProfile : Profile
{
    public MenuManagementWebAutoMapperProfile()
    {
        CreateMap<MenuCreateViewModel, MenuCreateDto>();
    }
}