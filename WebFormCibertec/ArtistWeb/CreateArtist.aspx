<%@ Page Title="" Language="C#" MasterPageFile="~/Site/CibertecTemplate.master" AutoEventWireup="true" CodeBehind="CreateArtist.aspx.cs" Inherits="WebFormCibertec.ArtistWeb.CreateArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ButtonContent" runat="server">
    <a class="btn btn-info" href="ListArtist.aspx">
       Go Back
    </a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ArtistContent" runat="server">

    <div id="success" class="alert alert-success" role="alert">
        <strong>Success!</strong>The records was created.
    </div>

    <div id="error" class="alert alert-danger" role="alert">
        <strong>Error!</strong>The records was created.
    </div>

    <div class="row">
        <h3>Create New Artist</h3>
    </div>
    <div class="row">
      <label>Artist Name:</label>
        <input type="text" required="required" id="Name"/>
    </div>

    <div class="row">
       <button class="btn btn-submit" onclick="insertArtist();return false">
           Create
       </button>
    </div>
    <script type="text/javascript">
        $(function () {
            $('.alert').hide();
        });

        function insertArtist() {
            $('.alert').hide();

            var name = document.getElementById('Name').value;
            $.ajax({
                type: 'POST',
                url: 'CreateArtist.aspx/InsertArtist',
                contentType: 'application/json',
                dataType: 'json',
                data: "{'name':'" + name + "'}",
                success: function (data, status) {
                    $('#success').show();
                    document.getElementById('Name').value=''
                },
                error: function () {
                     $('#error').show();
                }
            }); 
        }

    </script>
</asp:Content>
