using FluentValidation;
using Microsoft.Extensions.Localization;
using Snow.MenuManagement.Localization;
using SuperAbp.MenuManagement.Localization;

namespace SuperAbp.MenuManagement.Menus
{
    public class MenuCreateDtoValidator : AbstractValidator<MenuCreateDto>
    {
        public MenuCreateDtoValidator(IStringLocalizer<MenuManagementResource> localizer)
        {
            Include(new MenuCreateUpdateDtoValidator(localizer));
        }
    }
}