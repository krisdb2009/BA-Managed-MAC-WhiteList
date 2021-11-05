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

    <a class="btn btn-default" href="../" role="button" style="margin-right:20px;">
        <span class="glyphicon glyphicon-menu-left" aria-hidden="true"></span> Back
    </a>

    <div class="btn-group" role="group">
        <button type="button" class="btn btn-danger">
            <span class="glyphicon glyphicon-remove" aria-hidden="true"></span> Delete
        </button>
        <button type="button" class="btn btn-warning">
            <span class="glyphicon glyphicon-off" aria-hidden="true"></span> Disable
        </button>
        <button type="button" class="btn btn-success">
            <span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Enable
        </button>
    </div>

    <hr />

    <div class="form-group">
        <label for="MainContent_inputDesc">Description</label>
        <asp:TextBox CssClass="form-control" OnTextChanged="inputDesc_TextChanged" ID="inputDesc" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="MainContent_inputVLAN">VLAN</label>
        <asp:DropDownList ID="inputVLAN" CssClass="form-control" runat="server"></asp:DropDownList>
    </div>

    <button type="submit" class="btn btn-default">
        <span class="glyphicon glyphicon glyphicon-ok" aria-hidden="true"></span> Save
    </button>

</asp:Content>