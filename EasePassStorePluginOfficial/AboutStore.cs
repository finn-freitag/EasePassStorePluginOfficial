﻿using EasePassExtensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasePassStorePluginOfficial
{
    public class AboutStore : IAboutPlugin
    {
        public string PluginName => "Ease Pass Store Official";

        public string PluginDescription => "Adds plugin store functionality to Ease Pass.";

        public string PluginAuthor => "Ease Pass Team";

        public string PluginAuthorURL => "https://github.com/FrozenAssassine/EasePass";

        public Uri PluginIcon => Icon.GetIconUri();
    }
}
