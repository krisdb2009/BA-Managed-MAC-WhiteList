using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace BA_Managed_MAC_WhiteList.ManageDevices
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TableHeaderRow header = new TableHeaderRow();
            header.TableSection = TableRowSection.TableHeader;
            header.Cells.Add(new TableHeaderCell() { Text = "Edit" });
            header.Cells.Add(new TableHeaderCell() { Text = "MAC Address" });
            header.Cells.Add(new TableHeaderCell() { Text = "Description" });
            tblDevices.Rows.Add(header);

            DirectoryEntry de = new DirectoryEntry("LDAP://OU=Wifi Devices,OU=BA_Users,DC=ad,DC=belowaverage,DC=org");

            foreach(DirectoryEntry child in de.Children)
            {
                TableRow device = new TableRow();
                string mac = child.Properties["sAMAccountName"].Value.ToString();
                TableCell editBtnCell = new TableCell();
                Button editBtn = new Button();
                editBtn.Text = "Edit";
                editBtn.CssClass = "btn btn-default";
                editBtn.Attributes.Add("mac-address", mac);
                editBtn.Click += EditBtn_Click;
                editBtnCell.Controls.Add(editBtn);
                device.Cells.Add(editBtnCell);
                device.Cells.Add(new TableCell() { Text =  mac});
                device.Cells.Add(new TableCell() { Text = child.Properties["description"].Value?.ToString() });
                tblDevices.Rows.Add(device);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Response.Redirect("/ManageDevices/Device/" + btn.Attributes["mac-address"]);
        }
    }
}