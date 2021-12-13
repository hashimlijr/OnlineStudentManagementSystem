<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorDashboard.aspx.cs" Inherits="OnlineStudentManagementSystem.InstructorDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>

    <style>

            /* Table Styles */

            .table-wrapper{
                margin: 10px 70px 70px;
                /*box-shadow: 0px 35px 50px rgba( 0, 0, 0, 0.2 );*/
            }

            .fl-table {
                border-radius: 5px;
                font-size: 12px;
                font-weight: normal;
                border: none;
                border-collapse: collapse;
                width: 100%;
                max-width: 100%;
                white-space: nowrap;
                background-color: white;
            }

            .fl-table td, .fl-table th {
                text-align: center;
                padding: 8px;
                background: #080710;
                color: white;
            }

            .fl-table td {
                border-right: 1px solid #f8f8f8;
                font-size: 12px;
            }

            .fl-table thead th {
                color: #ffffff;
                background: #4FC3A1;
            }


            .fl-table thead th:nth-child(odd) {
                color: #ffffff;
                background: #324960;
            }

            .fl-table tr:nth-child(even) {
                background: #F8F8F8;
            }

    </style>
</head>
<body>
    <form id="instructorDashboardForm" runat="server">
        <div >
            
            <asp:Button ID="btn_GetAllStudents" runat="server" Text="Get All Students" OnClick="btn_GetAllStudents_Click" />
            <br />
            <br />
            <asp:DropDownList ID="ddl_Course" runat="server"></asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btn_GetStudentsFromCourse" runat="server" Text="Get Students From Course" />
            <br />
            <br />
            <asp:Label ID="lbl_CurrentStudent" runat="server" Text="Selected student:"></asp:Label>
            <br />
            <br />
            <div class="table-wrapper">
                <div class="fl-table">
                    <asp:GridView ID="gv_Students" runat="server" OnSelectedIndexChanged="gv_Students_SelectedIndexChanged" AutoGenerateSelectButton="True" Width="406px"></asp:GridView>
                </div>
            </div>
            
            

        </div>
    </form>
</body>
</html>
