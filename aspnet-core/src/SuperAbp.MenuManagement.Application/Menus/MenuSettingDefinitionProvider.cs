using SuperAbp.MenuManagement.Menus;
using Volo.Abp.Settings;

namespace SuperAbp.MenuManagement.Menus
{
    /// <summary>
    /// SettingDefinitionProvider
    /// </summary>
    public class MenuSettingDefinitionProvider : SettingDefinitionProvider
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    MenuSettings.MaxPageSize,
                    "100",
                    isVisibleToClients: true
                )
            );
        }
    }
}