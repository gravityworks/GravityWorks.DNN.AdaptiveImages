<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Default.ascx.cs" Inherits="GravityWorks.AdaptiveImages.Default" %>

<asp:Label ID="lblError" runat="server" />

Settings are saved in the web.config, please be aware updating these settings will cause an application reset. 
<div>
    <div>
        The resolution break-points to use (screen widths, in pixels)
        <asp:TextBox ID="txtBreaks" runat="server" />
    </div>

    <div>
        where to store the generated re-sized images. This folder must be writable
        <asp:TextBox ID="txtCachePath" runat="server" />
    </div>

    <div>
        The quality of any generated JPGs on a scale of 0 to 100
        <asp:TextBox ID="txtjpegQuality" runat="server" />
    </div>

    <div>
        check that the responsive image isn't stale (ensures updated source images are re-cached)
        <asp:TextBox ID="txtWatchCache" runat="server" />
    </div>

    <div>
        How long the BROWSER cache should last in seconds. (604800 - 7 days by default)
        <asp:TextBox ID="txtBrowserCache"  runat="server" />
    </div>

    <div>
    If there's no cookie false sends the largest var resolutions version (TRUE sends smallest)
    <asp:TextBox ID="txtMobileFirst" runat="server" />
    </div>

    <div>
        The name of the cookie containing the resolution value
        <asp:TextBox ID="txtCookieName"  runat="server" />
    </div>

    <asp:Button ID="btnSave" Text="Save" OnClick="btnSave_Click" runat="server" />
</div>