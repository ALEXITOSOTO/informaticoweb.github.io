<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Componentes.aspx.cs" Inherits="ComponentesInformaticos.Componentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lbl_id_comp" runat="server" Text="ID"></asp:Label>
    <asp:TextBox ID="txt_id_comp" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>
    <asp:Label ID="lbl_nombre_comp" runat="server" Text="Nombre"></asp:Label>
    <asp:TextBox ID="txt_nombre_comp" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:Label ID="lbl_marca_comp" runat="server" Text="Marca"></asp:Label>
    <asp:DropDownList ID="slt_marca_comp" runat="server" CssClass="form-control"></asp:DropDownList>
    <asp:Label ID="lbl_color_comp" runat="server" Text="Color"></asp:Label>
    <asp:DropDownList ID="slt_color_comp" runat="server" CssClass="form-control"></asp:DropDownList>
    <asp:Label ID="lbl_disponibilidad_comp" runat="server" Text="Disponibilidad"></asp:Label>
    <asp:TextBox ID="txt_disponibilidad_comp" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
    <asp:Label ID="lbl_precio_comp" runat="server" Text="Precio"></asp:Label>
    <asp:TextBox ID="txt_precio_comp" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
    <asp:Button ID="btn_guardar" runat="server" Text="Guardar" OnClick="btn_guardar_Click" />
</asp:Content>
