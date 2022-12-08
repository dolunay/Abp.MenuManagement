namespace SuperAbp.MenuManagement;

public static class MenuManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = "SuperAbp";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "SuperAbpMenuManagement";
}
