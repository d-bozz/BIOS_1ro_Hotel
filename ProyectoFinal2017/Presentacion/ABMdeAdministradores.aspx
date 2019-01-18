<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdministrador.master" AutoEventWireup="true" CodeFile="ABMdeAdministradores.aspx.cs" Inherits="ABMdeAdministradores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">


<div>
    
        <table style="width:100%; margin-top: 67px;">
            <tr>
                <td class="style1" colspan="3">
                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
                    </td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
                </td>
                <td class="center" style="width: 154px">
                    <asp:TextBox ID="txtuser" runat="server" style="text-align: center"></asp:TextBox>
                </td>
                <td class="style1">
                    <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                        Text="Buscar" style="font-weight: 700; text-align: right;" />
                </td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
                </td>
                <td class="center" style="width: 154px">
                    <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    <asp:Label ID="Label3" runat="server" Text="Nombre:"></asp:Label>
                </td>
                <td style="text-align: center; color: #000000; width: 154px;" class="style5">
                    <asp:TextBox ID="txtnombre" runat="server"></asp:TextBox>
                </td>
                <td class="style1">
                    <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                        Text="Limpiar" style="font-weight: 700" Width="83px" />
                </td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    <asp:Label ID="Label6" runat="server" Text="Cargo:"></asp:Label>
                </td>
                <td class="center" style="width: 154px">
                    <asp:DropDownList ID="ddlCargos" runat="server">
                        <asp:ListItem Value="administrativo">Administrativo</asp:ListItem>
                        <asp:ListItem Value="jefe">Jefe</asp:ListItem>
                        <asp:ListItem Value="gerente">Gerente</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    &nbsp;</td>
                <td class="center" style="width: 154px">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
                        onclick="btnAgregar_Click" style="font-weight: 700" />
                </td>
                <td class="center" style="width: 154px">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                        onclick="btnModificar_Click" style="font-weight: 700" Width="98px" />
                </td>
                <td class="style1">
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                        onclick="btnEliminar_Click" style="font-weight: 700" 
                        CausesValidation="False" />
                </td>
            </tr>
            <tr>
                <td class="style3" style="width: 115px">
                    &nbsp;</td>
                <td class="center" style="width: 154px">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: right">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    <p>
        &nbsp;</p>




</asp:Content>

