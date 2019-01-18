<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCliente.master" AutoEventWireup="true" CodeFile="RealizarunaReserva.aspx.cs" Inherits="RealizarunaReserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">


    <table style="width: 100%;">
        <tr>
            <td style="width: 204px">
                <asp:Label ID="Label1" runat="server" Text="Seleccione una Categoria : "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cboCategorias" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="cboHoteles_SelectedIndexChanged">
                    <asp:ListItem Value="1">1 estrella</asp:ListItem>
                    <asp:ListItem Value="2">2 estrellas</asp:ListItem>
                    <asp:ListItem Value="3">3 estrellas</asp:ListItem>
                    <asp:ListItem Value="4">4 estrellas</asp:ListItem>
                    <asp:ListItem Value="5 ">5 estrellas</asp:ListItem>
                </asp:DropDownList>
                </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 204px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 204px">
                <asp:Label ID="Label2" runat="server" Text="Seleccione un Hotel : "></asp:Label>
            </td>
            <td>
                <asp:GridView ID="GVHoteles" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" Width="427px" 
                    AutoGenerateColumns="False">
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField SelectText="Seleccion" ShowSelectButton="True" />
                        <asp:BoundField DataField="NombreHotel" HeaderText="Nombre" />
                        <asp:BoundField DataField="Calle" HeaderText="Calle" />
                        <asp:BoundField DataField="NroPuerta" HeaderText="Numero" />
                        <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                        <asp:BoundField DataField="Fax" HeaderText="Fax" />
                        <asp:CheckBoxField DataField="AccesoPlaya" HeaderText="Acceso a Playa" />
                        <asp:CheckBoxField DataField="Piscina" HeaderText="Piscina" />
                        <asp:ImageField DataImageUrlField="Foto" HeaderText="Foto">
                        </asp:ImageField>
                    </Columns>
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 204px">&nbsp;</td>
            <td>
                <asp:Button ID="btnSeleccionarhot" runat="server" Text="Seleccionar" 
                    onclick="btnSeleccionarhot_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 204px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 204px">
                <asp:Label ID="Label3" runat="server" Text="Seleccione una Habitacion:"></asp:Label>
            </td>
            <td>
                <asp:GridView ID="GVHabitaciones" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" Width="427px" 
                    AutoGenerateColumns="False">
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField SelectText="Seleccion" ShowSelectButton="True" />
                        <asp:BoundField DataField="NroHabitacion" HeaderText="Numero" />
                        <asp:BoundField DataField="Piso" HeaderText="Piso" />
                        <asp:BoundField DataField="CantHuespedes" HeaderText="Capacidad" />
                        <asp:BoundField DataField="CostoDiario" HeaderText="Costo Diario" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    </Columns>
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 204px">&nbsp;</td>
            <td>
                <asp:Button ID="btnSeleccionarHab" runat="server" 
                    onclick="btnSeleccionarHab_Click" Text="Seleccionar" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 204px">&nbsp;</td>
            <td>
                <asp:Label ID="lblHabitacion" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 204px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 204px">Seleccione la Fecha de Inicio:</td>
            <td>
                <asp:Calendar ID="cldFechaInicio" runat="server" 
                    onselectionchanged="cldFechaInicio_SelectionChanged"></asp:Calendar>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 204px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 204px">Seleccione la Fecha de Fin:</td>
            <td>
                <asp:Calendar ID="cldFechaFin" runat="server" onselectionchanged="cldFechaFin_SelectionChanged" 
                    ></asp:Calendar>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 204px; height: 35px;"></td>
            <td style="height: 35px"></td>
            <td style="height: 35px"></td>
        </tr>
        <tr>
            <td style="width: 204px">&nbsp;</td>
            <td>
                <asp:Button ID="btnCalcularCosto" runat="server" 
                    onclick="btnCalcularCosto_Click" Text="Calcular Costo" />
                <asp:Label ID="lblCostoTotal" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 204px">&nbsp;</td>
            <td>
                <asp:Button ID="btnReservar" runat="server" onclick="btnReservar_Click" 
                    Text="Reservar" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 204px">&nbsp;</td>
            <td>
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>





</asp:Content>

