<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AsOnReportsViewer.ascx.cs" Inherits="VistaGL.Views.Shared.AsOnReportsViewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<% var model = (Model as VistaGL.Modules.Reports.ReportSearchViewModel); %>


<%--<%: model.BankAccountId %>--%>

<form runat="server" id="nnn">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release"></asp:ScriptManager>

        <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server" ShowPrintButton="true" AsyncRendering="false" SizeToReportContent="true" ClientIDMode="Static">
        </rsweb:ReportViewer>--%>
    </div>

    <%-- <style type="text/css">
        /*table[title="Refresh"] {
            display:none!important;
        }*/

        table[title="Print"] {
            overflow: visible !important;
            display: block;
        }

        #1_ReportViewer1_ctl05_ctl04_ctl00 {
            overflow: visible !important;
        }

        #1_ReportViewer1_ctl05_ctl05_ctl00 {
            overflow: visible !important;
        }

        #1_ReportViewer1_ctl05_ctl06_ctl00 {
            overflow: visible !important;
        }

        #1_ReportViewer1_ctl05_ctl07_ctl00 {
            overflow: visible !important;
        }

        #1_ReportViewer1_ctl05_ctl08_ctl00 {
            overflow: visible !important;
        }
    </style>  --%>

    <%--    <script type="text/javascript">
        $(function () {
            //$(".aspNetDisabled").css("display", "block");

           // $("table[title='Refresh']").css("display", "none");
        });

    </script>--%>
</form>
