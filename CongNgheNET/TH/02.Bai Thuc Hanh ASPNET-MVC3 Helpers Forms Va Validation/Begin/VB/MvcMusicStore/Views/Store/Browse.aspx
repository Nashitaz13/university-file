<%@ Page Title="" Language="vb" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcMusicStore.StoreBrowseViewModel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Browse Albums
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Browsing Genre: <%:Model.Genre.Name%></h2>

    <ul>

    <%
    For Each album In Model.Albums
       %>
       <li><%:album.Title%></li>
    <%
    Next album
    %>
    </ul>

</asp:Content>