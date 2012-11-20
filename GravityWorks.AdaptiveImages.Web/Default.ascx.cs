using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Definitions;
using DotNetNuke.Entities.Tabs;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;

namespace GravityWorks.AdaptiveImages
{
    public partial class Default :  PortalModuleBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadSettings();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveAdaptiveSettings();
        }

        private string GetSetting(string settingName)
        {
            string tmpRtn = string.Empty;

            try
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
                tmpRtn = config.AppSettings.Settings[settingName].Value;
            }
            catch (Exception ex)
            {
                lblError.Text = string.Format("Error reading {0} from web.config. message={1}", settingName, ex.Message);
            }
           
            // return
            return tmpRtn;
        }

        private void LoadSettings()
        {
            txtBreaks.Text =   GetSetting("AdaptiveImages.ResolutionBreakpoints");
            txtCachePath.Text =  GetSetting("AdaptiveImages.CachePath");
            txtjpegQuality.Text = GetSetting("AdaptiveImages.JpegQuality");
            txtWatchCache.Text = GetSetting("AdaptiveImages.WatchCache");
            txtBrowserCache.Text =  GetSetting("AdaptiveImages.BrowserCache");
            txtMobileFirst.Text = GetSetting("AdaptiveImages.MobileFirst"); 
            txtCookieName.Text = GetSetting("AdaptiveImages.CookieName"); 
        }

        private void SaveAdaptiveSettings()
        { 
            SaveSetting("AdaptiveImages.ResolutionBreakpoints", txtBreaks.Text); 
            SaveSetting("AdaptiveImages.CachePath", txtCachePath.Text ); 
            SaveSetting("AdaptiveImages.JpegQuality",txtjpegQuality.Text ); 
            SaveSetting("AdaptiveImages.WatchCache", txtWatchCache.Text); 
            SaveSetting("AdaptiveImages.BrowserCache", txtBrowserCache.Text); 
            SaveSetting("AdaptiveImages.MobileFirst", txtMobileFirst.Text);
            SaveSetting("AdaptiveImages.CookieName", txtCookieName.Text); 
        }

        private void SaveSetting(string settingName, string value)
        {
            try
            {
                Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                config.AppSettings.Settings[settingName].Value = value;
                config.Save();
            }
            catch (Exception ex)
            {
                lblError.Text = string.Format("Error saving {0} to the web.config message={1}", settingName, ex.Message);
            }
        }
      
    }
}