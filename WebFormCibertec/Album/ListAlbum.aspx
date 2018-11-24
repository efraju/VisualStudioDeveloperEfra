﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site/CibertecTemplate.master" AutoEventWireup="true" CodeBehind="ListAlbum.aspx.cs" Inherits="WebFormCibertec.Album.ListAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
    <a class="btn btn-info" href="#">
        Create Album
    </a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">
     <div class="row">
        <h3>Album List</h3>
    </div>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server"
        ConnectionString="<%$ ConnectionStrings:Cibertec %>"
        SelectCommand="GetAllAbum"
        SelectCommandType="StoredProcedure">

    </asp:SqlDataSource>

    <div class="row-grid">
        <asp:GridView
            runat="server"
            ID="albumGriedView"
            DataKeyNames="AlbumId"
            AllowPaging="true"
            AllowSorting="true"
            AutoGenerateColumns="true"
            DataSourceID="SqlDataSource2" 
            AutoGenerateDeleteButton="true"
            AutoGenerateEditButton="true"
            PageSize="25">

        </asp:GridView>
    </div>
</asp:Content>