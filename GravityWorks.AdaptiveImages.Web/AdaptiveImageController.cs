using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GravityWorks.AdaptiveImages
{
    public class AdaptiveImageController : IUpgradeable
    {
        public string UpgradeModule(string Version)
        {

            Install.AddModuleToAdminSection();

            return Version;
        }
    }
}