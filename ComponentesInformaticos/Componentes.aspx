<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Componentes.aspx.cs" Inherits="ComponentesInformaticos.Componentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <br />
    <asp:Label ID="lbl_id_comp" runat="server" Text="ID"></asp:Label>
    <asp:TextBox ID="txt_id_comp" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>
     <br />
    <asp:Label ID="lbl_nombre_comp" runat="server" Text="Nombre"></asp:Label>
    <asp:TextBox ID="txt_nombre_comp" runat="server" CssClass="form-control" OnTextChanged="txt_nombre_comp_TextChanged"></asp:TextBox>
     <br />
    <asp:Label ID="lbl_marca_comp" runat="server" Text="Marca"></asp:Label>
    <asp:DropDownList ID="slt_marca_comp" runat="server" CssClass="form-control"></asp:DropDownList>
    <br />
    <asp:Label ID="lbl_color_comp" runat="server" Text="Color"></asp:Label>
    <asp:DropDownList ID="slt_color_comp" runat="server" CssClass="form-control"></asp:DropDownList>  
     <br />
    <asp:Label ID="lbl_disponibilidad_comp" runat="server" Text="Disponibilidad"></asp:Label>
    <asp:TextBox ID="txt_disponibilidad_comp" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
    <br />
    <asp:Label ID="lbl_precio_comp" runat="server" Text="Precio"></asp:Label>
    <asp:TextBox ID="txt_precio_comp" runat="server" CssClass="form-control" TextMode="Number" BorderStyle="Inset"></asp:TextBox>
    <br />
    <asp:Button ID="btn_guardar" runat="server" Text="Guardar" OnClick="btn_guardar_Click" CssClass="btn btn-success" />
        </div>
        <div class="col-md-6">
            <br />
            <asp:Label ID="lbl_titulo_componentes" runat="server" Text="Componentes Informaticos"></asp:Label>
            <asp:GridView ID="grid_componentes" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-hover" DataKeyNames="id_comp">
                <Columns>
                    <asp:BoundField DataField="id_comp" HeaderText="ID" />
                    <asp:BoundField DataField="nombre_comp" HeaderText="NOMBRE" />
                    <asp:BoundField DataField="marca_comp" HeaderText="MARCA" />
                    <asp:BoundField DataField="disponibilidad_comp" HeaderText="DISPONIBILIDAD" />
                    <asp:BoundField DataField="color_comp" HeaderText="COLOR" />
                    <asp:BoundField DataField="precio_comp" HeaderText="PRECIO" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
