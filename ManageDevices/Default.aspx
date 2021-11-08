<%@ Page Title="Devices" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BA_Managed_MAC_WhiteList.ManageDevices.Default" %>

<asp:Content ID="mdContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-header">
        <h3>Devices</h3>
    </div>

    <a class="btn btn-default" href="./New" role="button">
        <span class="glyphicon glyphicon-plus" aria-hidden="true"></span> Add
    </a>

    <hr />

    <asp:Table CssClass="table" ID="tblDevices" runat="server"></asp:Table>

</asp:Content>