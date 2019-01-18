<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdministrador.master" AutoEventWireup="true" CodeFile="ListadodeHabitacionesyReservas.aspx.cs" Inherits="ListadodeHabitacionesyReservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">


    <table style="width: 100%;">
        <tr>
            <td style="width: 205px; height: 64px;">
                &nbsp;
                <asp:Label ID="Label1" runat="server" Text="Seleccione un Hotel: "></asp:Label>
            </td>
            <td style="height: 64px; width: 595px">
                <asp:DropDownList ID="cboHoteles" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;
            </td>
            <td style="height: 64px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 205px; height: 236px">
                &nbsp;
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Seleccione una Habitacion: "></asp:Label>
            </td>
            <td style="height: 236px; width: 595px;">
                &nbsp;
                <asp:GridView ID="GVCompleto" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" Width="427px">
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField SelectText="Seleccion" ShowSelectButton="True" />
                    </Columns>
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
            <td style="height: 236px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 205px">
                &nbsp;</td>
            <td style="width: 595px">
                <asp:DropDownList ID="ddlReservas" runat="server">
                    <asp:ListItem>Todas</asp:ListItem>
                    <asp:ListItem Value="Activa">Activas</asp:ListItem>
                    <asp:ListItem Value="Finalizada">Finalizadas</asp:ListItem>
                    <asp:ListItem Value="Cancelada">Canceladas</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 205px">
                &nbsp;
            </td>
            <td style="width: 595px">
                <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" 
                    onclick="btnSeleccionar_Click" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 205px">
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Reservas relacionadas:"></asp:Label>
            </td>
            <td style="width: 595px">
                <asp:GridView ID="GVSeleccion" runat="server" 
                    Width="212px" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                        <asp:BoundField DataField="fechainicio" HeaderText="Fecha Inicio" />
                        <asp:BoundField DataField="fechafin" HeaderText="Fecha Fin" />
                        <asp:BoundField DataField="estadoactual" HeaderText="Estado" />
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 205px">
                &nbsp;</td>
            <td style="width: 595px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 205px">
                &nbsp;</td>
            <td style="width: 595px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 205px; height: 32px;">
                </td>
            <td style="width: 595px; height: 32px;">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </td>
            <td style="height: 32px">
                </td>
        </tr>
    </table>




</asp:Content>

