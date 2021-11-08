<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BA_Managed_MAC_WhiteList._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-header">
        <h1>BA-Managed MAC <small>Control Panel</small></h1>
    </div>

    <div class="jumbotron">
          <p>This control panel is for managing the MAC Address WhiteList for BA-Managed WiFi. The password for BA-Managed SSID is "belowaverage".</p>
          <p><a class="btn btn-primary btn-lg" href="/ManageDevices" role="button">Manage Devices</a></p>
    </div>

</asp:Content>