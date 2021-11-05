using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace BA_Managed_MAC_WhiteList.ManageDevices
{
    public partial class Device : System.Web.UI.Page
    {
        private DirectoryEntry ADDevice;
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] path = Request.Path.Split('/');
            string mac = path[path.Length - 1];
            if (!Regex.IsMatch(mac, "(((([0-9]|[a-f]){2})-){5}([0-9]|[a-f]){2})"))
            {
                Response.Redirect("/ManageDevices");
                return;
            }
            lblSelectedDevice.Text = mac;
            ADDevice = new DirectoryEntry("LDAP://CN=" + mac + ",OU=Wifi Devices,OU=BA_Users,DC=ad,DC=belowaverage,DC=org");
            string desc = ADDevice.Properties["description"].Value.ToString();
            lblSelectedDeviceDescript.Text = desc;
            inputDesc.Text = desc;

            DirectoryEntry groups = new DirectoryEntry("LDAP://OU=Groups,OU=BA_Users,DC=ad,DC=belowaverage,DC=org");
            foreach(DirectoryEntry group in groups.Children)
            {
                if (!group.Name.StartsWith("CN=BA_User_Wifi")) continue;
                if (group.Name == "CN=BA_User_Wifi_MAC") continue;
                inputVLAN.Items.Add(new ListItem(group.Properties["sAMAccountName"].Value.ToString()));
            }



        }

        protected void inputDesc_TextChanged(object sender, EventArgs e)
        {
            ADDevice.Properties["description"].Value = inputDesc.Text;
            ADDevice.CommitChanges();
        }
    }
}