<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="OnlineStudentManagementSystem.Contact" %>

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
            background-image: url('images/contactBackground.png');
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
        form *{
            letter-spacing: 0.5px;
            outline: none;
            border: none;
        }

        input{
            display: block;
            height: 50px;
            width: 200px;
            background-color: rgba(211, 212, 218, 0.56);
            border-radius: 3px;
            padding: 0 10px;
            margin-top: 8px;
            font-size: 14px;
            font-weight: 300;
        }

        .input {
            display: block;
            height: 150px;
            width: 300px;
            background-color: rgba(211, 212, 218, 0.56);
            border-radius: 3px;
            padding: 0 10px;
            margin-top: 8px;
            font-size: 18px;
            font-weight: 300;
            font-family: sans-serif;
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

        .main{
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
    <form id="formContact" runat="server">
        <div>
            <header>
            <nav>
                <ul>
                    <li><a href="Index.aspx">Home</a></li>
                    <li><a href="About.aspx">About</a></li>
                    <li><a href="Contact.aspx">Contact</a></li>
                </ul>               
            </nav>
        </header>
        </div>
        <div class="main">
            <h1>Contact us</h1>
            <h4>Please write your name and email. After this you can write your feedbacks.</h4>
            <asp:Label ID="lbl_Status" runat="server" Text="Status"></asp:Label>
            <br />

            <asp:TextBox ID="tb_Name" runat="server" placeholder="Your name*"></asp:TextBox>
            <br />

            <asp:TextBox ID="tb_Email" runat="server" placeholder="Your email*"></asp:TextBox>
            <br />

            <asp:TextBox ID="tb_data" runat="server" class="input" placeholder="Your feedbacks or questions" TextMode="MultiLine" Rows="10"></asp:TextBox>
            <br />

            <asp:Button ID="btn_Send" runat="server" class="button" Text="Send" OnClick="btn_Send_Click" />
        </div>
    </form>
</body>
</html>
