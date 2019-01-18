<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdministrador.master" AutoEventWireup="true" CodeFile="ABMdeHoteles.aspx.cs" Inherits="ABMdeHoteles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">



<div>
    
        <table style="width:100%; margin-top: 67px;">
            <tr>
                <td class="style1" rowspan="7" style="width: 221px">
                    <asp:Image ID="img" runat="server" Width="224px" Height="222px" />
                    </td>
                <td class="style1" colspan="3">
                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
                    </td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    <asp:Label ID="Label1" runat="server" Text="Hotel:"></asp:Label>
                </td>
                <td class="center" style="width: 154px">
                    <asp:TextBox ID="txtHotel" runat="server" style="text-align: center"></asp:TextBox>
                </td>
                <td class="style1">
                    <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                        Text="Buscar" style="font-weight: 700; text-align: right;" />
                </td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="valNombre" runat="server" 
                        ControlToValidate="txtHotel" ErrorMessage="El nombre es obligatorio." 
                        ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    <asp:Label ID="Label2" runat="server" Text="Calle:"></asp:Label>
                </td>
                <td class="center" style="width: 154px">
                    <asp:TextBox ID="txtCalle" runat="server"></asp:TextBox>
                </td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="valCalle" runat="server" 
                        ControlToValidate="txtCalle" ErrorMessage="La calle es obligatoria." 
                        ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    <asp:Label ID="Label3" runat="server" Text="Nro. Puerta:"></asp:Label>
                </td>
                <td style="text-align: center; color: #000000; width: 154px;" class="style5">
                    <asp:TextBox ID="txtNroPuerta" runat="server"></asp:TextBox>
                </td>
                <td class="style1">
                    <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                        Text="Limpiar" style="font-weight: 700" Width="83px" 
                        CausesValidation="False" />
                </td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="valPuerta" runat="server" 
                        ControlToValidate="txtNroPuerta" 
                        ErrorMessage="El numero de puerta es obligatorio." ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valNroPuerta" runat="server" 
                        ControlToValidate="txtNroPuerta" 
                        ErrorMessage="El numero de puerta debe ser positivo." ForeColor="#FF3300" 
                        ValidationExpression="^[0-9]*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    <asp:Label ID="Label6" runat="server" Text="Ciudad:"></asp:Label>
                </td>
                <td class="center" style="width: 154px">
                    <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox>
                </td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="valCiudad" runat="server" 
                        ControlToValidate="txtCiudad" ErrorMessage="La ciudad es obligatoria." 
                        ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    <asp:Label ID="Label4" runat="server" Text="Telefono:"></asp:Label>
                </td>
                <td class="center" style="width: 154px">
                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                </td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="valTelefono" runat="server" 
                        ControlToValidate="txtTelefono" ErrorMessage="El telefono es obligatorio." 
                        ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    <asp:Label ID="Label5" runat="server" Text="Fax:"></asp:Label>
                </td>
                <td class="center" style="width: 154px">
                    <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                </td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="valFax" runat="server" 
                        ControlToValidate="txtFax" ErrorMessage="El fax es obligatorio." 
                        ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="center" style="width: 221px; height: 64px">
                    &nbsp;</td>
                <td class="center" style="width: 115px; height: 64px">
                    <asp:Label ID="Label7" runat="server" Text="Acceso Playa:"></asp:Label>
                </td>
                <td class="center" style="width: 154px; height: 64px">
                    <asp:CheckBox ID="RBPlaya" runat="server" />
                </td>
                <td class="style1" style="height: 64px">
                    </td>
                <td class="style1" style="height: 64px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="center" style="width: 221px; height: 14px">
                    &nbsp;</td>
                <td class="center" style="width: 115px; height: 14px">
                    <asp:Label ID="Label8" runat="server" Text="Piscina:"></asp:Label>
                </td>
                <td class="center" style="width: 154px; height: 14px">
                    <asp:CheckBox ID="RBPiscina" runat="server" />
                </td>
                <td class="style1" style="height: 14px">
                    </td>
                <td class="style1" style="height: 14px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="center" style="width: 221px">
                    &nbsp;</td>
                <td class="center" style="width: 115px">
                    <asp:Label ID="Label9" runat="server" Text="Estrellas:"></asp:Label>
                </td>
                <td class="center" style="width: 154px">
                    <asp:RadioButtonList ID="RBEstrellas" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="valEstrellas" runat="server" 
                        ControlToValidate="RBEstrellas" 
                        ErrorMessage="Debe ingresar las estrellas del hotel." ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="center" style="width: 221px">
                    &nbsp;</td>
                <td class="center" style="width: 115px">
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="Fotos:"></asp:Label>
                </td>
                <td class="center" colspan="2">
                    &nbsp;<asp:FileUpload ID="fileimageFoto" runat="server" Width="443px" />
                </td>
                <td class="center">
                    <asp:RequiredFieldValidator ID="valFoto" runat="server" 
                        ControlToValidate="fileimageFoto" 
                        ErrorMessage="No ha seleccionado ninguna imagen." ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="center" style="width: 221px">
                    &nbsp;</td>
                <td class="center" style="width: 115px">
                    &nbsp;</td>
                <td class="center" style="width: 154px">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="center" style="width: 221px">
                    &nbsp;</td>
                <td class="center" style="width: 115px">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
                        onclick="btnAgregar_Click" style="font-weight: 700" />
                </td>
                <td class="center" style="width: 154px">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                        onclick="btnModificar_Click" style="font-weight: 700" Width="98px" />
                </td>
                <td class="style1">
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                        onclick="btnEliminar_Click" style="font-weight: 700" 
                        CausesValidation="False" />
                </td>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" style="width: 221px">
                    &nbsp;</td>
                <td class="style3" style="width: 115px">
                    &nbsp;</td>
                <td class="center" style="width: 154px">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center; width: 221px;">
                    &nbsp;</td>
                <td colspan="3" style="text-align: center">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td style="text-align: center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 221px;">
                    &nbsp;</td>
                <td colspan="3" style="text-align: right">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ForeColor="#FF3300" />
                </td>
                <td style="text-align: right">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    <p>
        &nbsp;</p>



</asp:Content>

