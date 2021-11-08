<%@ Page Title="Device" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Device.aspx.cs" Inherits="BA_Managed_MAC_WhiteList.ManageDevices.Device" %>

<asp:Content ID="DevContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h3>
            <asp:Label ID="lblSelectedDevice" runat="server"></asp:Label>
            <small>
                <asp:Label ID="lblSelectedDeviceDescript" runat="server"></asp:Label>
            </small>
        </h3>
    </div>

    <% if (Request.QueryString.ToString() == "delete") { %>
        <div class="alert alert-warning" style="display:flex;align-items:center;" role="alert">
            <span style="flex:1;">
                <strong>Warning!</strong> Are you sure you want to delete this device?
            </span>
            <a style="" href="?delete_confirm" class="btn btn-danger">
                <span class="glyphicon glyphicon-remove" aria-hidden="true"></span> Confirm
            </a>
        </div>
    <% } %>

    <a class="btn btn-default" href="../" role="button">
        <span class="glyphicon glyphicon-menu-left" aria-hidden="true"></span> Back
    </a>

    <div class="btn-group" style="float:right;" role="group">
        <a href="?delete" class="btn btn-danger">
            <span class="glyphicon glyphicon-remove" aria-hidden="true"></span> Delete
        </a>
    </div>

    <hr />

    <div class="form-group">
        <label for="MainContent_inputDesc">Description</label>
        <asp:TextBox CssClass="form-control" OnTextChanged="inputDesc_TextChanged" ID="inputDesc" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="MainContent_inputVLAN">VLAN</label>
        <asp:DropDownList OnSelectedIndexChanged="inputVLAN_SelectedIndexChanged" ID="inputVLAN" CssClass="form-control" runat="server"></asp:DropDownList>
    </div>

    <button type="submit" class="btn btn-default">
        <span class="glyphicon glyphicon glyphicon-ok" aria-hidden="true"></span> Save
    </button>

</asp:Content>