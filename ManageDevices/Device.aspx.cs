using System;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.DirectoryServices;

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

            if (Request.QueryString.ToString() == "delete_confirm")
            {
                ADDevice.DeleteTree();
                Response.Redirect("/ManageDevices", true);
                return;
            }


            string desc = ADDevice.Properties["description"].Value?.ToString();
            if (inputDesc.Text == "")
            {
                inputDesc.Text = desc;
                lblSelectedDeviceDescript.Text = desc;
            }
            else
            {
                lblSelectedDeviceDescript.Text = inputDesc.Text;
            }
            if (inputVLAN.Items.Count == 0)
            {
                DirectoryEntry groups = new DirectoryEntry("LDAP://OU=Groups,OU=BA_Users,DC=ad,DC=belowaverage,DC=org");
                inputVLAN.Items.Add(new ListItem("None"));
                foreach (DirectoryEntry group in groups.Children)
                {
                    if (!group.Name.StartsWith("CN=BA_User_Wifi")) continue;
                    if (group.Name == "CN=BA_User_Wifi_MAC") continue;
                    ListItem li = new ListItem(group.Properties["sAMAccountName"].Value.ToString(), group.Properties["distinguishedName"].Value.ToString());
                    inputVLAN.Items.Add(li);
                    if (group.Properties["member"].Contains(ADDevice.Properties["distinguishedName"].Value.ToString())) li.Selected = true;
                }
            }
        }

        protected void inputDesc_TextChanged(object sender, EventArgs e)
        {
            ADDevice.Properties["description"].Value = inputDesc.Text;
            ADDevice.CommitChanges();
        }

        protected void inputVLAN_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ddd = ADDevice.Properties["distinguishedName"].Value.ToString();
            foreach (string group in ADDevice.Properties["memberOf"])
            {
                DirectoryEntry deGroup = new DirectoryEntry("LDAP://" + group);
                if(deGroup.Properties["member"].Contains(ddd))
                {
                    deGroup.Properties["member"].Remove(ddd);
                }
                deGroup.CommitChanges();
            }
            DirectoryEntry macGroup = new DirectoryEntry("LDAP://CN=BA_User_Wifi_MAC,OU=Groups,OU=BA_Users,DC=ad,DC=belowaverage,DC=org");
            macGroup.Properties["member"].Add(ddd);
            macGroup.CommitChanges();
            if (inputVLAN.SelectedValue == "None") return;
            DirectoryEntry selGroup = new DirectoryEntry("LDAP://" + inputVLAN.SelectedValue);
            selGroup.Properties["member"].Add(ddd);
            selGroup.CommitChanges();
        }
    }
}