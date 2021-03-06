<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexAfterLogin.aspx.cs" Inherits="OnlineStudentManagementSystem.IndexAfterLogin" %>

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
            height: 85vh;
            background-image: url('images/indexBackground2.jpg');
            background-size: 800px,600px;
            font-family: sans-serif;
            margin-top: 80px;
            padding: 30px;
            background-repeat: no-repeat;
            background-position: right;
            background-position-y: center;
            background-position-y: center;
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

        .atag{            
            color: black;
            text-decoration: none;
            background: white;
            border-block-style: hidden;
            border-block-color: white;
            cursor: pointer;
            font-size: 14px;
            border: white;
        }

        .right{
            position:relative;
            left:100%;
        }

        h1{
            font-size: 80px;
            font-weight: normal;
            margin-bottom: 5px;
        }

        h2{
            font-size: 42px;
            font-weight: lighter;
            margin-top: 10px;
        }

        h3{
            font-size: 25px;
            font-weight: lighter;
            margin-top: 90px;
            margin-bottom: 30px;
        }

        .welcome{
            text-align: left;
            font-family: serif;
            border-left-style: solid;
            border-left-width: 0px;
            margin-right: 50%;
            margin-top: 80px;
        }

        .button{
            background-color: #8f3c87;
            font-size: 18px;
            border-radius: 8px;
            box-shadow: 0px 2px 2px 0px #00000045;
            width: 150px;
            color: white;
            height: 50px;
            cursor: pointer;
            font-family: sans-serif;
        }
    </style>
</head>
<body>
    <form id="formIndexAfterLogin" runat="server">
        <div>
            <header>
            <nav>
                <ul>
                    <li><a href="#" class="atag">Home</a></li>
                    <li><a href="About.aspx" class="atag">About</a></li>
                    <li><a href="Contact.aspx" class="atag">Contact</a></li>
                    <li><asp:Button ID="btn_Logout" class="atag" runat="server" Text="Log Out" OnClick="btn_Logout_Click"/></li>
                </ul>               
            </nav>
        </header>
        </div>
        <div class="welcome">
            <h1>Welcome!</h1>
            <h2>Student Management System</h2>
            <h3>Glad to see you! Click the following button to return dashboard.</h3>

            <asp:Button ID="btn_Return" class="button" runat="server" Text="Return" OnClick="btn_Return_Click" />
        </div>
    </form>
</body>
</html>
