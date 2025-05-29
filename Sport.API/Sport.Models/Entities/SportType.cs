﻿using System.ComponentModel;

namespace Sport.Models.Entities
{
    public enum SportType
    {
        [Description("Football")]
        Football,
        [Description("Basketball")]
        Basketball,
        [Description("Tennis")]
        Tennis,
        [Description("Baseball")]
        Baseball,
        [Description("Soccer")]
        Soccer,
        [Description("Golf")]
        Golf,
        [Description("Other")]
        Other
    }
}
