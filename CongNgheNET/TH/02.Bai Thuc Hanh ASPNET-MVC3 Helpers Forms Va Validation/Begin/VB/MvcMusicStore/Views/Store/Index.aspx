<%@ Page Title="" Language="vb" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcMusicStore.StoreIndexViewModel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Browse Genres
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Browse Genres</h2>

    <p>Select from <%:Model.NumberOfGenres%></p>

    <ul>
        <%
        For Each genreName As String In Model.Genres
           %>
           <li>
           <%:Html.ActionLink(genreName, "Browse", New With {Key .genre = genreName}, Nothing)%>
           </li>
        <%
        Next genreName
        %>
    </ul>

</asp:Content>