<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BudgetReportsViewer.ascx.cs" Inherits="VistaGL.Views.Shared.BudgetReportsViewer" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<form runat="server" id="nnn">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" ShowPrintButton="true" AsyncRendering="false" SizeToReportContent="true" ClientIDMode="Static"></rsweb:ReportViewer>
    </div>

</form>

