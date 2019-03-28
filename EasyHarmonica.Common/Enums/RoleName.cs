using System.ComponentModel;

namespace EasyHarmonica.Common.Enums
{
    public enum RoleName
    {
        [Description("Administrator")]
        Administrator,

        [Description("Manager")]
        Manager,

        [Description("Moderator")]
        Moderator,

        [Description("User")]
        User,

        [Description("Guest")]
        Guest
    }
}
