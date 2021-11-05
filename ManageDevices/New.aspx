<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="BA_Managed_MAC_WhiteList.ManageDevices.New" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h3>New Device</h3>
    </div>

    <a class="btn btn-default" href="../ManageDevices" role="button">
        <span class="glyphicon glyphicon-menu-left" aria-hidden="true"></span> Back
    </a>

    <hr />

    <div class="form-group">
        <label for="MainContent_inputDesc">MAC Address</label>
        <asp:TextBox OnTextChanged="inputMAC_TextChanged" CssClass="form-control" ID="inputMAC" runat="server"></asp:TextBox>
    </div>

    <button type="submit" class="btn btn-default">
        <span class="glyphicon glyphicon-plus" aria-hidden="true"></span> Continue
    </button>

</asp:Content>