﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditInstructor.aspx.cs" Inherits="OnlineStudentManagementSystem.EditInstructor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Instructor</title>

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
            bottom: -800px;
        }

        form{
            height: 1420px;
            width: 400px;
            background-color: rgba(255,255,255,0.13);
            position: absolute;
            transform: translate(-50%,-50%);
            top: 100%;
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

        .buttonDelete{
            margin-top: 50px;
            width: 100%;
            background-color: #ee4949;
            color: #eaf0fb;
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

        .social a{
          text-decoration: none;
        }

        .label{            
            font-size: 12px;
        }

        .dropdownlist{
            color: rgb(8, 7, 16);
            width: 100%;
            height: 42px;
        }

        #delete{
            background: #ee4949;
            color: #eaf0fb;
        }
    </style>
</head>
<body>

    <div class="background">
        <div class="shape"></div>
        <div class="shape"></div>
    </div>

    <form id="editInstructorForm" runat="server">

        <div>
            <h3>Edit Here</h3>

            <br />
            
            <asp:Label ID="lbl_status" runat="server" Text="* required fields"></asp:Label>

            <label for="name">Name*</label>
            <asp:TextBox ID="tb_name" runat="server" placeholder="Name"></asp:TextBox>

            <label for="surname">Surname*</label>
            <asp:TextBox ID="tb_surname" runat="server" placeholder="Surname"></asp:TextBox>

            <label for="fatherName">Father Name*</label>
            <asp:TextBox ID="tb_fatherName" runat="server" placeholder="Father Name"></asp:TextBox>

            <label for="email">Email*</label>
            <asp:TextBox ID="tb_email" runat="server" placeholder="Email"></asp:TextBox>            

            <label for="password">Password*</label>
            <asp:TextBox ID="tb_password" runat="server" placeholder="Password"></asp:TextBox>

            <label for="conpassword">Password confirmation*</label>
            <asp:TextBox ID="tb_conpassword" runat="server" placeholder="Confirm password"></asp:TextBox>

            <label for="branch">Choose branch of instructor</label>
            <asp:DropDownList ID="DropDownList_Branch" class="dropdownlist" runat="server"></asp:DropDownList>

            <label for="date">Instructor's date of birth*</label>
            <asp:TextBox ID="tb_currentDate" runat="server" placeholder="Date"></asp:TextBox>

            <label for="date">Choose date of birth*</label>
            <asp:TextBox ID="tb_date" textmode="Date" runat="server" placeholder="Date"></asp:TextBox>


            <asp:Button ID="btn_update" class="button" runat="server" Text="Update" OnClick="btn_update_Click"/>

            <asp:Button ID="btn_delete" class="buttonDelete" runat="server" Text="Delete" OnClick="btn_delete_Click"/>

            <div class="social">
                <asp:Button ID="btn_Cancel" class="go" runat="server" Text="Cancel" OnClick="btn_Cancel_Click"/>
            </div>

        </div>

    </form>

</body>
</html>