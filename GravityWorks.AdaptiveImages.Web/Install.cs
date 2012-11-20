using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Definitions;
using DotNetNuke.Entities.Tabs;
using System.Linq;

namespace GravityWorks.AdaptiveImages
{
    public static class Install
    {
        private const string MODULE_NAME = "GravityWorks AdaptiveImages";
        private const string TAB_NAME = "Adaptive Images 13";
        private const string MODULE_DEF_NAME = "GravityWorks-AdaptiveImages";
        private const int DNN_HOST_TAB = 7;

        public static void AddModuleToAdminSection()
        {
            int tabId = CreateAdaptiveHostTab(TAB_NAME);

            if (tabId > 0)
                AddAdaptiveModuleToPage(tabId);
        }

        private static void AddAdaptiveModuleToPage(int tabId)
        {
            ModuleDefinitionInfo moduleDefinitionInfo = ModuleDefinitionController.GetModuleDefinitionByFriendlyName(MODULE_DEF_NAME);

            ModuleInfo moduleInfo = new ModuleInfo() { TabID = tabId, ModuleOrder = 1, ModuleTitle = MODULE_NAME, PaneName = "Content Pane", ModuleDefID = moduleDefinitionInfo.ModuleDefID, CacheTime = moduleDefinitionInfo.DefaultCacheTime, InheritViewPermissions = true, AllTabs = false, Alignment = "Top" };

            ModuleController moduleController = new ModuleController() ;
            moduleController.AddModule(moduleInfo);

            DataCache.ClearModuleCache(tabId);
        }

        private static bool DoesNamedTabExistInParentTab(string tabName, int parentTabId)
        {
            return new TabController()
                .GetTabsByParentId(parentTabId) //ArrayList of Tabs from Parent (used because Host Tabs Have no Portal Associated with Them) otherwise we would use GetTabsByParent(parentId, portalId) which returns as List<TabInfo>
                .Cast<TabInfo>() //Casting to allow for ToList()
                .ToList() // To Generalize it
                .Any(a => a.TabName == tabName); //Will return true if exists
        }

        private static int CreateAdaptiveHostTab(string tabName)
        {
            int tmpRtn = 0;
            int parentTabId = DNN_HOST_TAB;

            TabController controller = new TabController();

            if (DoesNamedTabExistInParentTab(tabName, parentTabId) == false)
            {
                TabInfo adaptiveTab = new TabInfo() { TabName = tabName, IsSuperTab = true, ParentId = parentTabId, IconFile = string.Format("~/DesktopModules/{0}/images/host-image.png", MODULE_DEF_NAME), IconFileLarge = string.Format("~/DesktopModules/{0}/images/host-image-32px.png", MODULE_DEF_NAME) };

                controller.AddTab(adaptiveTab);
                DataCache.ClearModuleCache(adaptiveTab.TabID);
                tmpRtn = adaptiveTab.TabID;
            }

            // return
            return tmpRtn;
        }
    }
}