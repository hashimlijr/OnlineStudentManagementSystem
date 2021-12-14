﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineStudentManagementSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign in</title>
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css"/>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;500;600&display=swap" rel="stylesheet"/>
    <!--Stylesheet-->
    <style media="screen">
        *,
        *:before,
        *:after{
            padding: 0;
            margin: 0;
            box-sizing: border-box;
        }
        body{
            background-color: #080710;
        }
        .background{
            width: 430px;
            height: 520px;
            position: absolute;
            transform: translate(-50%,-50%);
            left: 50%;
            top: 50%;
        }
        .background .shape{
            height: 200px;
            width: 200px;
            position: absolute;
            border-radius: 50%;
        }
        .shape:first-child{
            background: linear-gradient(
                #1845ad,
                #23a2f6
            );
            left: -80px;
            top: -80px;
        }
        .shape:last-child{
            background: linear-gradient(
                to right,
                #ff512f,
                #f09819
            );
            right: -30px;
            bottom: -80px;
        }
        form{
            height: 600px;
            width: 400px;
            background-color: rgba(255,255,255,0.13);
            position: absolute;
            transform: translate(-50%,-50%);
            top: 50%;
            left: 50%;
            border-radius: 10px;
            backdrop-filter: blur(10px);
            border: 2px solid rgba(255,255,255,0.1);
            box-shadow: 0 0 40px rgba(8,7,16,0.6);
            padding: 50px 35px;
        }
        form *{
            font-family: 'Poppins',sans-serif;
            color: #ffffff;
            letter-spacing: 0.5px;
            outline: none;
            border: none;
        }
        form h3{
            font-size: 32px;
            font-weight: 500;
            line-height: 42px;
            text-align: center;
        }

        label{
            display: block;
            margin-top: 30px;
            font-size: 16px;
            font-weight: 500;
        }
        input{
            display: block;
            height: 50px;
            width: 100%;
            background-color: rgba(255,255,255,0.07);
            border-radius: 3px;
            padding: 0 10px;
            margin-top: 8px;
            font-size: 14px;
            font-weight: 300;
        }
        /*::placeholder{
            color: #e5e5e5;
        }*/
        .button{
            margin-top: 50px;
            width: 100%;
            background-color: #ffffff;
            color: #080710;
            padding: 15px 0;
            font-size: 18px;
            font-weight: 600;
            border-radius: 5px;
            cursor: pointer;
        }
        .social{
          margin-top: 30px;
          display: flex;
          cursor: pointer;
        }
        .social div{
          background: red;
          width: 100%;
          border-radius: 3px;
          padding: 5px 10px 10px 5px;
          background-color: rgba(255,255,255,0.27);
          color: #eaf0fb;
          text-align: center;
        }
        .social div:hover{
          background-color: rgba(255,255,255,0.47);
        }
        /*.social .fb{
          margin-left: 25px;
        }*/
        .social a{
          text-decoration: none;
        }
        .label{            
            font-size: 12px;
        }

    </style>
</head>
<body>
    <div class="background">
        <div class="shape"></div>
        <div class="shape"></div>
    </div>
    <form id="loginForm" runat="server">
        <div>
            <h3>Login Here</h3>

            <label for="email">Email</label>
            <asp:TextBox ID="tb_email" runat="server" placeholder="Email"></asp:TextBox>

            <label for="password">Password</label>
            <asp:TextBox ID="tb_password" runat="server" placeholder="Password"></asp:TextBox>

            <asp:Label ID="lbl_status" class="label" runat="server" Text="Status"></asp:Label>

            <asp:Button ID="btn_login" class="button" runat="server" Text="Sign in" OnClick="btn_login_Click" />

            <div class="social">                
                    <asp:Button ID="btn_ResetPassword" class="social" runat="server" Text="Forget password?" OnClick="btn_ResetPassword_Click" />             
            </div>
        </div>
    </form>
</body>
</html>
