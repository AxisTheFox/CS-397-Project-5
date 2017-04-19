<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieDetails.aspx.cs" Inherits="FoxBraydonProject5.MovieDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <div id="header">
            <h1>Movie Search</h1>
        </div>

        <div id="movieInfo" runat="server">
            <h2><asp:Label ID="movieTitle" runat="server"></asp:Label></h2>
            <p>
                <asp:Label ID="genre" runat="server" Text=""></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="releaseDate" runat="server" Text=""></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="runtime" runat="server" Text=""></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="rating" runat="server" Text=""></asp:Label>
            </p>
            <asp:Image ID="moviePoster" runat="server" />
            <h3>Plot:</h3>
            <p><asp:Label ID="plot" runat="server" Text=""></asp:Label></p>
        </div>
        

    </div>
    </form>
</body>
</html>
