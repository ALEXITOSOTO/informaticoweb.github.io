<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="ComponentesInformaticos.Vender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <br />
<asp:Label ID="lbl_id_cli" runat="server" Text="ID"></asp:Label>
<asp:TextBox ID="txt_id_comp" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>
<br />
<asp:Label ID="lbl_ci_cli" runat="server" Text="Cedula de identidad"></asp:Label>
<asp:TextBox ID="txt_ci_cli" runat="server" ReadOnly="False" CssClass="form-control" TextMode="Number"></asp:TextBox>
<br />
<asp:Label ID="lbl_nombre_cli" runat="server" Text="Nombre"></asp:Label>
<asp:TextBox ID="txt_nombre_cli" runat="server" CssClass="form-control"></asp:TextBox>
<br />
<asp:Label ID="lbl_apellido_cli" runat="server" Text="Apellido"></asp:Label>
<asp:TextBox ID="txt_apellido_cli" runat="server" CssClass="form-control"></asp:TextBox>
<br />
<asp:Label ID="lbl_sexo_cli" runat="server" Text="Sexo"></asp:Label>
<asp:DropDownList ID="slt_sexo_cli" runat="server" CssClass="form-control"></asp:DropDownList>  
<br />
<asp:Label ID="lbl_fecha_nacimiento_cli" runat="server" Text="Fecha de Nacimiento"></asp:Label>
<asp:TextBox ID="txt_fecha_nacimiento_cli" runat="server" ReadOnly="False" CssClass="form-control" TextMode="Date"></asp:TextBox>
<br />
<asp:Label ID="lbl_direccion_cli" runat="server" Text="Direccion"></asp:Label>
<asp:TextBox ID="txt_direccion_cli" runat="server" CssClass="form-control"></asp:TextBox>
<br />
<asp:Label ID="lbl_correo_cli" runat="server" Text="Correo Electronico"></asp:Label>
<asp:TextBox ID="txt_correo_cli" runat="server" CssClass="form-control"></asp:TextBox>
<br />
<asp:Label ID="lbl_telefono_cli" runat="server" Text="Telefono"></asp:Label>
<asp:TextBox ID="txt_telefono_cli" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
<br />
    <asp:Button ID="btn_guardar_cliente" runat="server" Text="Guardar Nuevo Cliente" OnClick="btn_guardar_cliente_Click" />
    <br />
    <asp:Label ID="lbl_clientes" runat="server" Text="Clientes"></asp:Label>
    <asp:GridView ID="grid_clientes" runat="server" AutoGenerateColumns="False" CssClass="table table-dark" DataKeyNames="id_cli">
        <Columns>
            <asp:BoundField DataField="id_cli" HeaderText="ID" />
            <asp:BoundField DataField="ci_cli" HeaderText="Cedula" />
            <asp:BoundField DataField="nombre_cli" HeaderText="Nombre" />
            <asp:BoundField DataField="apellido_cli" HeaderText="Apellido" />
            <asp:BoundField DataField="sexo_cli" HeaderText="Sexo" />
            <asp:BoundField DataField="fecha_nacimiento_cli" HeaderText="Fecha de Nacimiento" />
            <asp:BoundField DataField="direccion_cli" HeaderText="Direccion" />
            <asp:BoundField DataField="correo_cli" HeaderText="Correo" />
            <asp:BoundField DataField="telefono_cli" HeaderText="Telefono" />
        </Columns>
            </asp:GridView>
  

</asp:Content>
