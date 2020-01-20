<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyControl.ascx.cs" Inherits="LaborExchange2._0.MyControl" %>

<asp:LinkButton ID="btnTest" runat="server" OnClick="timeTest_Click" />

<script type="text/javascript">
    $("#<%=MyName%>").on("click", function (e) { alert("Было вызвано событие пользовательского контрола <%=AlertName%>"); });
</script>