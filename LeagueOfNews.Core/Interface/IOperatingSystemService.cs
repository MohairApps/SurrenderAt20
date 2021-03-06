﻿namespace LeagueOfNews.Core.Interface
{
    public enum SystemType
    {
        Unsupported = -1,
        UWP,
        Android,
        iOS
    }

    public interface IOperatingSystemService
    {
        SystemType GetSystemType();
    }
}