<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdministrador.master" AutoEventWireup="true" CodeFile="ABMdeHabitaciones.aspx.cs" Inherits="ABM_de_Habitaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">


<div>
    
        <table style="width:100%; margin-top: 67px;">
            <tr>
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
                    <asp:RequiredFieldValidator ID="valHotel" runat="server" 
                        ControlToValidate="txtHotel" ErrorMessage="El hotel no puede ser vacio." 
                        ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    <asp:Label ID="Label2" runat="server" Text="Habitacion:"></asp:Label>
                </td>
                <td class="center" style="width: 154px">
                    <asp:TextBox ID="txtHabitacion" runat="server"></asp:TextBox>
                </td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="valHabitacion" runat="server" 
                        ControlToValidate="txtHabitacion" 
                        ErrorMessage="La habitacion no puede ser vacia." ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valHabitacionNum" runat="server" 
                        ControlToValidate="txtHabitacion" 
                        ErrorMessage="El numero de habitacion debe ser positivo." ForeColor="#FF3300" 
                        ValidationExpression="^[0-9]*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    <asp:Label ID="Label3" runat="server" Text="Piso:"></asp:Label>
                </td>
                <td style="text-align: center; color: #000000; width: 154px;" class="style5">
                    <asp:TextBox ID="txtPiso" runat="server"></asp:TextBox>
                </td>
                <td class="style1">
                    <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                        Text="Limpiar" style="font-weight: 700" Width="83px" 
                        CausesValidation="False" />
                </td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="valPiso" runat="server" 
                        ControlToValidate="txtPiso" ErrorMessage="El piso no puede ser vacio." 
                        ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valPisoNum" runat="server" 
                        ControlToValidate="txtPiso" ErrorMessage="El piso debe ser positivo." 
                        ForeColor="#FF3300" ValidationExpression="^[0-9]*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    <asp:Label ID="Label6" runat="server" Text="Huespedes:"></asp:Label>
                </td>
                <td class="center" style="width: 154px">
                    <asp:TextBox ID="txtHuespedes" runat="server"></asp:TextBox>
                </td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="valHuespedes" runat="server" 
                        ControlToValidate="txtHuespedes" 
                        ErrorMessage="La cantidad de huespedes no puede ser vacia." ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valHuespedesNum" runat="server" 
                        ControlToValidate="txtHuespedes" 
                        ErrorMessage="La cantidad de huespedes debe ser positiva." ForeColor="#FF3300" 
                        ValidationExpression="^[0-9]*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    <asp:Label ID="Label4" runat="server" Text="Costo Diario:"></asp:Label>
                </td>
                <td class="center" style="width: 154px">
                    <asp:TextBox ID="txtCostoDiario" runat="server"></asp:TextBox>
                </td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="valCostoDiario" runat="server" 
                        ControlToValidate="txtCostoDiario" 
                        ErrorMessage="El costo diario no puede ser vacio." ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valCostoDiarioNum" runat="server" 
                        ControlToValidate="txtCostoDiario" ErrorMessage="El costo diario debe ser positivo." 
                        ForeColor="#FF3300" ValidationExpression="^[0-9]*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="center" style="width: 115px">
                    <asp:Label ID="Label5" runat="server" Text="Descripcion:"></asp:Label>
                </td>
                <td class="center" style="width: 154px">
                    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                </td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style1">
                    <asp:RequiredFieldValidator ID="valDescripcion" runat="server" 
                        ControlToValidate="txtDescripcion" 
                        ErrorMessage="La descripcion no puede ser vacia." ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
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
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
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
                <td colspan="3" style="text-align: center">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td style="text-align: center">
                    &nbsp;</td>
            </tr>
            <tr>
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

