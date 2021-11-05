using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace BA_Managed_MAC_WhiteList.ManageDevices
{
    public partial class Device : System.Web.UI.Page
    {
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

        }
    }
}