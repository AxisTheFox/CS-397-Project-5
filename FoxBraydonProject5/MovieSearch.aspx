<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieSearch.aspx.cs" Inherits="FoxBraydonProject5.MovieSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Movie Search</title>
    <link rel="stylesheet" type="text/css" href="Style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <div id="header">
            <h1>Movie Search</h1>
        </div>

        <p>
            Enter a movie title:
        <br />
            <asp:TextBox ID="searchTextBox" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
        </p>

        <div id="movieResults" runat="server">
            
        </div>
    
    </div>
    </form>
</body>
</html>
