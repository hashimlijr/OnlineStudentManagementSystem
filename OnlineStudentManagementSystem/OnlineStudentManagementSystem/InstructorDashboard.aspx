<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorDashboard.aspx.cs" Inherits="OnlineStudentManagementSystem.InstructorDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" />
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />   
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Open+Sans&display=swap');
        *{
	        list-style: none;
	        text-decoration: none;
	        margin: 0;
	        padding: 0;
	        box-sizing: border-box;
	        font-family: 'Open Sans', sans-serif;
        }
        body{
	        background: #f5f6fa;
        }
        .wrapper .sidebar{
	        background: rgb(23, 29, 34);
	        position: fixed;
	        top: 0;
	        left: 0;
	        width: 30%;
	        height: 100%;
	        padding: 20px 0;
	        transition: all 0.5s ease;
        }
        .wrapper .sidebar .profile{
            margin-bottom: 30px;
            text-align: center;
        }

        .wrapper .sidebar .profile img{
            display: block;
            width: 100px;
            height: 100px;
            border-radius: 50%;
            margin: 0 auto;
        }

        .wrapper .sidebar .profile h3{
            color: #ffffff;
            margin: 10px 0 5px;
        }

        .wrapper .sidebar .profile p{
            color: rgb(206, 240, 253);
            font-size: 14px;
        }
        .wrapper .sidebar ul li a{
            display: block;
            padding: 20px 30px;
            border-bottom: 2px solid #2d41e1;
            color: rgb(241, 237, 237);
            font-size: 16px;
            position: relative;
        }

        .wrapper .sidebar ul li a .icon{
            color: #dee4ec;
            width: 30px;
            display: inline-block;
        }

        .wrapper .sidebar ul li a:hover,
        .wrapper .sidebar ul li a.active{
            color: #2b40e0;

            background:white;
            border-right: 2px solid rgb(15, 38, 221);
        }

        .wrapper .sidebar ul li a:hover .icon,
        .wrapper .sidebar ul li a.active .icon{
            color: #2b40e0;
        }

        .wrapper .sidebar ul li a:hover:before,
        .wrapper .sidebar ul li a.active:before{
            display: block;
        }

        .button{
            display: block;
            color: #fcfcfc;
            background: #171d22;
            border-right: 3px solid rgb(15, 38, 221);
            padding: 20px 30px;
            border-bottom: 1px solid #2d41e1;
            position: relative;
            height: 60px;
            width: 100%;
            margin-top: 0px;
            text-align: center;
            font-size: 18px;
            border-top: 1px solid #2d41e1;
            border-left: 2px solid #171d22;
            cursor: pointer;
        }

        .wrapper .section{
	        width: calc(100% - 225px);
	        margin-left: 225px;
	        transition: all 0.5s ease;
        }
        .wrapper .section .top_navbar{
	        background: rgb(7, 105, 185);
	        height: 50px;
	        display: flex;
	        align-items: center;
	        padding: 0 30px;
 
        }
        .wrapper .section .top_navbar .hamburger a{
	        font-size: 28px;
	        color: #f4fbff;
        }
        .wrapper .section .top_navbar .hamburger a:hover{
	        color: #a2ecff;
        }
        .main{
            margin-left: 10%;
            margin-top: 10%;
            padding-top: 5%;
            padding-right: 50%;
            padding-bottom: 10%;
            font-size: 16px;
        }

        .dashboard{
            margin-left: 30%;
            margin-top: 10px;
            align-items: center;
            margin-bottom: 80%;
            padding-bottom: 100px;
            padding-left: 20px;
            padding-top: 40px;
        }

        .dashboard h1{
            font-size: 40px;
            text-align: center;
        }
        
    </style>
</head>
<body>
    <form id="studentDashboardForm" runat="server"> 

            <div class="wrapper">

             <!--Top Menu & Menu button-->

                <div class="sidebar">

                    <div class="profile">

                        <!--Profile Image-->

                        <img src="images/defaultProfile.png" alt="profile_picture" />

                        <!--Profile Title & Descruption--> 
                        
                        <h3>
                            <asp:Label ID="lbl_fullName" runat="server" Text="Full Name"></asp:Label>
                        </h3>

                        <p>
                            <asp:Label ID="lbl_profesion" runat="server" Text="Profesion"></asp:Label>
                        </p>

                    </div>

                     <!--Menu item-->
                        <ul>

                                <li>
                                    <a href="#" class="active">
                                        <span class="icon"><i class="fas fa-home"></i></span>
                                        <span class="item">My Dashboard</span>
                                    </a>
                                </li>
                            
                                <li>
                                    <asp:Button ID="btn_Profile" class="button" runat="server" Text="Profile" />  
                                </li>

                                <li>
                                    <asp:Button ID="btn_GetAllStudents" class="button" runat="server" Text="Get All Students" OnClick="btn_GetAllStudents_Click" />                                    
                                </li>

                                <li>
                                    <asp:Button ID="btn_AddGrade" class="button" runat="server" Text="Grade" OnClick="btn_AddGrade_Click"/>                                     
                                </li>

                                <li>
                                    <asp:Button ID="btn_Logout" class="button" runat="server" Text="Log Out" OnClick="btn_Logout_Click"/>                                                                          
                                </li>

                </ul>

               </div>
        
            </div>

        <div class="dashboard">
            <h1>Dashboard</h1>
            <div class="main">
                <%--<asp:Label ID="lbl_CurrentStudent" runat="server" Text="Selected student:"></asp:Label>--%>
                <%--<asp:TextBox ID="tb_Score" runat="server"></asp:TextBox>--%>
                <asp:GridView ID="gv_Students" runat="server" Width="406px"></asp:GridView>
                <asp:GridView ID="gv_Grades" runat="server" AutoGenerateSelectButton="True" Width="406px" OnSelectedIndexChanged="gv_Grades_SelectedIndexChanged"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>