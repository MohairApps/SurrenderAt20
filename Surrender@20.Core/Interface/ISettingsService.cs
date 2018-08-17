﻿using Surrender_20.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Surrender_20.Core.Interface
{

    public interface ISettingsService
    {
        NewsfeedNavigationParameter this[Setting PropertyName] { get; set; }
    }

    public enum Setting
    {
        Home, //TODO Add URL (e.g. HomeURL)
        PBE,
        Releases,
        RedPosts,
        People,
        ESports
    }
}