<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroCliente.aspx.cs" Inherits="RegistroCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .form-group {
            font-weight: 700;
        }
        .style1
        {
            width: 100%;
        }
        .control-label
        {
            font-weight: 700;
            color: #FF6600;
        }
        .style3
        {
            font-size: xx-large;
        }
        .style4
        {
            width: 781px;
        }
        .style5
        {
            width: 88px;
            font-weight: 700;
        }
        .style6
        {
            font-size: xx-large;
            width: 740px;
        }
        .style7
        {
            width: 740px;
        }
        .style9
        {
            color: #000000;
        }
        
        .style10
        {
            width: 740px;
            height: 26px;
        }
        .style11
        {
            width: 88px;
            font-weight: 700;
            height: 26px;
        }
        .style12
        {
            width: 781px;
            height: 26px;
        }
        .style13
        {
            width: 88px;
            font-weight: 700;
            text-align: center;
        }
        .auto-style1 {
            font-size: xx-large;
            width: 290px;
        }
        .auto-style2 {
            width: 290px;
        }
        .auto-style3 {
            width: 290px;
            height: 26px;
        }
        .auto-style4 {
            width: 290px;
            height: 68px;
        }
        .auto-style5 {
            width: 88px;
            font-weight: 700;
            text-align: center;
            height: 68px;
        }
        .auto-style6 {
            width: 781px;
            height: 68px;
        }
    </style>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function Nombre_onclick() {

        }

// ]]>
    </script>
</head>
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

<body background="images/fd2.jpg">
    <form id="form1" runat="server">
    
    


    <div class="container">
            <table class="style1">
                <tr>
                    <td class="auto-style1" style="text-align: left">
                        &nbsp;</td>
                    <td class="style3" colspan="2" style="text-align: left">
                        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label10" 
                            runat="server" Text="Registro"></asp:Label>
                            
                        </strong><hr></td>
                
                </tr>

                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td class="style4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="style5">
                        <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtNombre" ErrorMessage="El nombre no puede ser vacio" 
                            ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="style5">
                        Usuario:</td>
                    <td class="style4">
                        <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtUser" ErrorMessage="El usuario no puede ser vacio" 
                            ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="font-weight: 700">
                        &nbsp;</td>
                    <td class="style5" style="font-weight: 700; color: #FF6600;">
                        <span class="style9">
                        <asp:Label ID="Label3" runat="server" Text="Contraseña:"></asp:Label>
                        </span></td>
                    <td class="style4">
                        <asp:TextBox ID="txtContra" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtContra" ErrorMessage="La contrasenia no puede ser vacio" 
                            ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        </td>
                    <td class="style11">
                        <asp:Label ID="Label4" runat="server" Text="Repita Contraseña:"></asp:Label>
                    </td>
                    <td class="style12">
                        <asp:TextBox ID="txtContra2" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToCompare="txtContra" ControlToValidate="txtContra2" CssClass="style1" 
                            ErrorMessage="Las contrasenias no coinciden " ForeColor="Red" 
                            SetFocusOnError="True">*</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="style5">
                        <asp:Label ID="Label8" runat="server" Text="Direccion:"></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtDireccion" ErrorMessage="La direccion no puede ser vacio" 
                            ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="style5">
                        <asp:Label ID="Label6" runat="server" Text="Tarjeta:"></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="txttarjeta" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="txttarjeta" ErrorMessage="La tarjeta no puede ser vacio" 
                            ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td class="style4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td class="style4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td class="style4">
                        <asp:Button ID="btnRegistrar" runat="server" class="btn btn-dark" onclick="Button1_Click" 
                            Text="Registrar" style="font-weight: 700" />
                    &nbsp;<asp:Button ID="btnLimpiar" runat="server" class="btn btn-dark" onclick="btnLimpiar_Click" 
                        Text="Limpiar" style="font-weight: 700" Width="83px" CausesValidation="False" 
                            EnableTheming="True" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td class="style4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        &nbsp; &nbsp;</td>
                    <td class="auto-style5">
                        <asp:Label ID="Label9" runat="server"  Text="Agregar Telefono:"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txtTelefonoExtra" runat="server"></asp:TextBox>
                        &nbsp;
                        <asp:Button ID="btnAgregarTel" runat="server" class="btn btn-dark" onclick="btnAgregarTel_Click" 
                            Text="Agregar Telefono" CausesValidation="False" />
                        &nbsp;<asp:ListBox ID="lstTel" runat="server" Width="123px" Height="40px"></asp:ListBox>
                        &nbsp;<asp:Button ID="btnBorrar" runat="server" class="btn btn-dark" CausesValidation="False" 
                            onclick="btnBorrar_Click" Text="Borrar Seleccionado" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td class="style4">
                        <asp:Label ID="lblmensaje" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td class="style4">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="style5">
                        
                        &nbsp;</td>

                    </td>
                    <td class="style4">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
                        <a class="btn btn-primary btn-lg" href="Logueo.aspx" role="button">Volver</a></td>
                </tr>
            </table>
    </form>
    <!-- /form -->
        </div> <!-- ./container -->




    </div>
    </form>
</body>
</html>
