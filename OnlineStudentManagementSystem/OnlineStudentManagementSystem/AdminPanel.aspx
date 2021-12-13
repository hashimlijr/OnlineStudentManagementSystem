<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="OnlineStudentManagementSystem.AdminPanel" %>

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
            /*background-image: url('https://codetheweb.blog/assets/img/posts/style-a-navigation-bar-css/background.jpg');*/
            background-size: cover;
            font-family: sans-serif;
            /*margin-top: 80px;
            padding: 30px;*/
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
            position: relative;
            left: 100%;
        }
        .button{
            margin-top: 8px;
            width: 50%;
            background-color: #ffffff;
            color: #080710;
            padding: 15px 0;
            font-size: 14px;
            font-weight: 600;
            border-radius: 5px;
            cursor: pointer;
        }

        .menu{
            margin-top: 5%;
            /*width: 20%;*/
            box-sizing: border-box;
            position: inherit;
            display: block;
            /*border-bottom: 1px solid #2F2E31;*/
            /*padding: 15px 10px;*/
            line-height: 15px;
            box-sizing: border-box;
            flex: 1;
        }
        .main{
            display: flex;
        }
        .grid{
            background-color: #fff;
            margin-right: 20px;
            margin-top: 100px;
            /*margin-left: 5%;*/
            padding: 45px;
            color: black;
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
                    <li><a href="Index.aspx">Log Out</a></li>
                    <li><a href="#">Contact</a></li>
                </ul>       
            </nav>
        </header>
        </div>

        <div class="main">

            <div class="menu">
                <asp:Label ID="lbl_Status" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btn_CreateDB" class="button" runat="server" Text="Create DB" OnClick="btn_CreateDB_Click" />
                <br />
                <asp:Button ID="btn_AddStudent" class="button" runat="server" Text="Add Student" OnClick="btn_AddStudent_Click" />
                <br />
                <asp:Button ID="btn_EditStudent" class="button" runat="server" Text="Edit Student" OnClick="btn_EditStudent_Click"/>
                <br />
                <asp:Button ID="btn_AddInstructor" class="button" runat="server" Text="Add Instructor" OnClick="btn_AddInstructor_Click" />
                <br />
                <asp:Button ID="btn_EditInstructor" class="button" runat="server" Text="Edit Instructor" OnClick="btn_EditInstructor_Click"/>
                <br />
                <asp:Button ID="btn_AddCourse" class="button" runat="server" Text="Add Course" OnClick="btn_AddCourse_Click" />
                <br />
                <asp:Button ID="btn_EditCourse" class="button" runat="server" Text="Edit Course" OnClick="btn_EditCourse_Click"/>
                <br />
                <asp:Button ID="btn_AddBranch" class="button" runat="server" Text="Add Branch" OnClick="btn_AddBranch_Click" />
                <br />
                <asp:Button ID="btn_EditBranch" class="button" runat="server" Text="Edit Branch" OnClick="btn_EditBranch_Click"/>
                <br />
                <asp:Button ID="btn_AddProfesion" class="button" runat="server" Text="Add Profesion" OnClick="btn_AddProfesion_Click" />
                <br />
                <asp:Button ID="btn_EditProfesion" class="button" runat="server" Text="Edit Profesion" OnClick="btn_EditProfesion_Click"/>
            </div>

            <div class="grid">
                    
                <asp:GridView ID="gv_Students" runat="server" AutoGenerateSelectButton="True" Width="406px" OnSelectedIndexChanged="gv_Students_SelectedIndexChanged"></asp:GridView>
                    
                <br />
                    
                <asp:GridView ID="gv_Instructor" runat="server" AutoGenerateSelectButton="True" Width="406px" OnSelectedIndexChanged="gv_Instructor_SelectedIndexChanged"></asp:GridView> 
                
                <br />    
                
                <asp:GridView ID="gv_Courses" runat="server" AutoGenerateSelectButton="True" Width="406px" OnSelectedIndexChanged="gv_Courses_SelectedIndexChanged"></asp:GridView>                    
                 
                <br />   
                
                <asp:GridView ID="gv_Branch" runat="server" AutoGenerateSelectButton="True" Width="406px" OnSelectedIndexChanged="gv_Branch_SelectedIndexChanged"></asp:GridView>
                 
                <br />   
                
                <asp:GridView ID="gv_Profesion" runat="server" AutoGenerateSelectButton="True" Width="406px" OnSelectedIndexChanged="gv_Profesion_SelectedIndexChanged"></asp:GridView>                             
            </div>

        </div>
        
    </form>
</body>
</html>