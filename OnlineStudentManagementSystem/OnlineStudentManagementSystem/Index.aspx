<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="OnlineStudentManagementSystem.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <style>
        header img {
            height: 80px;
            margin-left: 40px;
        }
        body {
            height: 125vh;
            background-image: url('https://codetheweb.blog/assets/img/posts/style-a-navigation-bar-css/background.jpg');
            background-size: cover;
            font-family: sans-serif;
            margin-top: 80px;
            padding: 30px;
        }
        main {
            color: white;
        }

        header {
            background-color: white;
            position: fixed;
            top: 0;
            left: 0;
            right: 0;
            height: 80px;
            display: flex;
            align-items: center;
            box-shadow: 0 0 25px 0 black;
        }

        header * {
            display: inline;
        }

        header li {
            margin: 20px;
        }

        header li .right {
            align-items: flex-end;
        }

        header li a {
            color: black;
            text-decoration: none;
        }

        .right{
            position:relative;
            left:100%;
        }
    </style>
</head>
<body>
    <form id="formIndex" runat="server">
        <div>
            <header>
            <nav>
                <ul>
                    <li><a href="#">Home</a></li>
                    <li><a href="#">About</a></li>
                    <li><a href="#">Pricing</a></li>
                </ul>
                <div class="right">
                    <ul>
                        <li><a href="Login.aspx">Sign in</a></li>
                        <li><a href="#">Contact</a></li>
                    </ul>                 
                </div>
            </nav>
        </header>
        </div>
    </form>
</body>
</html>
