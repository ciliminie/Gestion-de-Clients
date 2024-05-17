<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionClients.aspx.cs" Inherits="gestion_de_client.GestionClients" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 113px;
        }

        .auto-style2 {
            color: #006600;
        }
    </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <h2>Gestion des Clients</h2>
            <div style="background-color: black ; padding: 20px">
                <asp:Image ID="Image1" runat="server" Height="68px" ImageUrl="~/Screenshot (25).png" />
                <br />
                Sélectionner un client :<asp:DropDownList ID="DrpClients" runat="server" OnSelectedIndexChanged="drpClients_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnMiseAJour" runat="server" Text="Mettre à jour" OnClick="btnMiseAJour_Click" style="height: 26px" />&nbsp;&nbsp;<asp:Button ID="BtnSupprimer" runat="server" Text="Supprimer" OnClick="btnSupprimer_Click" /><br />
                <br />
                Ou:&nbsp;<asp:Button ID="BtnNouveau" runat="server" Text="Créer nouveau" OnClick="btnNouveau_Click" />&nbsp;&nbsp;<asp:Button ID="BetnEnregistrer" runat="server" Text="Enregistrer" OnClick="btnEnregistrer_Click" /><br />
            </div>
            <br />
            <div style="background-color: black; padding: 20px"><strong>
                <asp:Label ID="lblMsg" runat="server" Text="Label" CssClass="auto-style2"></asp:Label></strong><table>
                    <tr>
                        <td class="auto-style1">Nom:</td>
                        <td>
                            <asp:TextBox ID="txtNom" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Prénom:</td>
                        <td>
                            <asp:TextBox ID="txtPrenom" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Adresse:</td>
                        <td>
                            <asp:TextBox ID="txtAdresse" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Ville:</td>
                        <td>
                            <asp:TextBox ID="txtVille" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
        </form>
    </body>
</html>
