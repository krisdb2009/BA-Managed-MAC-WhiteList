using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace BA_Managed_MAC_WhiteList.ManageDevices
{
    public partial class New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void inputMAC_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(inputMAC.Text, "(((([0-9]|[a-f]){2})-){5}([0-9]|[a-f]){2})"))
            {
                Response.Redirect("/ManageDevices/New?Error=BADMAC");
                return;
            }
            UserPrincipal up = new UserPrincipal(new PrincipalContext(ContextType.Domain, "ad.belowaverage.org", "OU=Wifi Devices,OU=BA_Users,DC=ad,DC=belowaverage,DC=org"));
            up.Name = inputMAC.Text;
            up.SamAccountName = inputMAC.Text;
            up.DisplayName = inputMAC.Text;
            up.GivenName = inputMAC.Text;
            up.UserPrincipalName = inputMAC.Text + "@ad.belowaverage.org";
            up.PasswordNeverExpires = true;
            up.UserCannotChangePassword = true;
            up.SetPassword(inputMAC.Text);
            up.Enabled = true;
            up.Save();
            Response.Redirect("/ManageDevices/Device/" + inputMAC.Text, true);
        }
    }
}